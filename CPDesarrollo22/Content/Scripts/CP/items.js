var detalle = [];
var tableRow;
var index;

var IID;

$(document).ready(function () {
	LlenaGrid();
	GetCatalogs();

	$("#itemForm").validate({
		lang: 'sp'
	});

	$("#frmcaptura").on('hidden.bs.modal', function (e) {
		limpiaCajas();
	});
});

function LlenaGrid() {
	$("#loading").show();

	$.ajax({
		url: "/Items/Grid",
		data: {},
		type: 'POST'
	}).done(function (data) {
		$("#loading").hide();

		llenaTabla(data);
	}).fail(function (x, y, z) {
		$("#avisoD").html(z);
		$("#alertaDanger").show();

	});
}
function llenaTabla(data) {
	//Detalle
	$('#dataGrid').DataTable().rows().remove().draw();
	if (data.Items !== null) {
		for (var i = 0; i < data.Items.length; i++) {
			var columnas = [
				data.Items[i].ArticulosID,
				data.Items[i].Nombre,
				data.Items[i].Articulo,
				data.Items[i].FamiliasID,
				"<button class='btnEliminaDetalle' style='border:none;' onclick='editar(" + JSON.stringify(data.Items[i]) + ")'><img src='../Content/Imagenes/edit.svg' height='10' width='10' /></button>",
				"<button class='btnEliminaDetalle' style='border:none;' onclick='eliminar(" + JSON.stringify(data.Items[i]) + ")'><img src='../Content/Imagenes/delete.svg' height='10' width='10' /></button>"
			];

			var rowIndex = $('#dataGrid').dataTable().fnAddData(columnas);  //Agrega al DOM
			var row = $('#dataGrid').dataTable().fnGetNodes(rowIndex);
		}
	}
}

$("#btnNuevo").click(function () {
	nuevo();
});

function nuevo() {
	limpiaCajas();
	$("#frmcaptura").modal("show");
	$('#frmcaptura').on('shown.bs.modal', function () {
		$('input[name="txtDes"]').focus();
	});
}

$("#btnGuardar").click(function () {
	UploadImage();
});

function UploadImage() {
	if ($("#itemForm").valid()) {
		var formData = new FormData();
		var file = $('#flImage')[0];
		if (file.files.length > 0) {
			formData.append('file', file.files[0]);

			$.ajax({
				url: "../Items/UploadImage",
				type: "POST",
				data: formData,
				contentType: false,
				processData: false,
				success: function (data) {
					Guardar(data.Result);
				},
				error: function (response) {
					$("#avisoD").html("Error el cargar la imagen");
					$("#alertaDanger").fadeTo(2000, 500).slideUp(500, function () {
						$("#alertaDanger").slideUp(500);
					});
				}
			});
		} else {
			var imageSrc = $("#previewImg").attr("src");
			var image = '';

			if (imageSrc !== '' && imageSrc !== null) {
				image = imageSrc.split('/');

				Guardar(image[image.length - 1]);
			} else {
				Guardar(image);
			}			
		}
	}
}

function Guardar(image) {
	if ($("#itemForm").valid()) {
		var id = $("#txtID").val();
		var name = $("#txtName").val();
		var nameOC = $("#txtNameOC").val();
		var item = $("#txtItem").val();
		var SATKey = $("#txtSATKey").val();
		var barcode = $("#txtBarCode").val();
		var charge = $("#txtCharge").val();
		var stockDays = $("#txtStockDays").val();
		var isKit = $("#chbIsKit").is(':checked') ? 1 : 0;
		var family = $("#txtFamily").val();
		var handleStock = $("#chbHandleStock").is(':checked') ? 1 : 0;
		var handlePetitions = $("#chbHandlePetitions").is(':checked') ? 1 : 0;
		var max = $("#txtMax").val();
		var min = $("#txtMin").val();
		var currency = $("#txtCurrency").val();
		var outdated = $("#chbOutdated").is(':checked') ? 1 : 0;
		var supplier = $("#txtSupplier").val();
		var ieps = $("#txtIEPS").val();
		var iva = $("#txtIVA").val();
		var reorder = $("#txtReorder").val();
		var deliveryTime = $("#txtDeliveryTime").val();
		var location = $("#txtLocation").val();
		var um = $("#txtUM").val();
		var active = $("#chbActive").is(':checked') ? 1 : 0;

		$.ajax({
			url: "../Items/Add",
			data: {
				articulosID: id,
				nombre: name,
				nombreOC: nameOC,
				articulo: item,
				claveSat: SATKey,
				codigoDeBarras: barcode,
				costo: charge,
				diasStock: stockDays,
				esUnKit: isKit,
				familiasID: family,
				manejaExistencia: handleStock,
				manejaPedimentos: handlePetitions,
				maximo: max,
				minimo: min,
				monedasID: currency,
				obsoleto: outdated,
				proveedoresID: supplier,
				ptjeIeps: ieps,
				ptjeIva: iva,
				reorden: reorder,
				tiempoDeEntrega: deliveryTime,
				ubicacion: location,
				unidadesDeMedidaID: um,
				activo: active,
				imagen: image
			},
			type: 'POST'
		}).done(function (data) {
			if (data.Result == "OK") {
				$("#avisoS").html("Guardado correctamente");
				$("#alertaSuccess").fadeTo(2000, 500).slideUp(500, function () {
					$("#alertaSuccess").slideUp(500);
				});
				limpiaCajas();
				$('#frmcaptura').on('shown.bs.modal', function () {
					$('#txtDes').focus();
				});

				Cerrar();
			}
			else {
				$("#avisoD").html(data.Result);
				$("#alertaDanger").fadeTo(2000, 500).slideUp(500, function () {
					$("#alertaDanger").slideUp(500);
				});
			}
		}).fail(function (x, y, z) {
			$("#avisoD").html(z);
			$("#alertaDanger").fadeTo(2000, 500).slideUp(500, function () {
				$("#alertaDanger").slideUp(500);
			});
		});
	}
}

function editar(item) {
	$("#txtID").val(item.ArticulosID);
	$("#txtName").val(item.Nombre);
	$("#txtNameOC").val(item.NombreOC);
	$("#txtItem").val(item.Articulo);
	$("#txtSATKey").val(item.ClaveSat);
	$("#txtBarCode").val(item.CodigoDeBarras);
	$("#txtCharge").val(item.Costo);
	$("#txtStockDays").val(item.DiasStock);
	$("#chbIsKit").prop('checked', (item.Esunkit === 1) ? true : false);
	$('#chbIsKit').bootstrapToggle((item.Esunkit === 1) ? 'on' : 'off');
	$("#txtFamily").val(item.FamiliasID);
	$("#chbHandleStock").prop('checked', (item.ManejaExistencia === 1) ? true : false);
	$('#chbHandleStock').bootstrapToggle((item.ManejaExistencia === 1) ? 'on' : 'off');
	$("#chbHandlePetitions").prop('checked', (item.Manejapedimentos === 1) ? true : false);
	$('#chbHandlePetitions').bootstrapToggle((item.Manejapedimentos === 1) ? 'on' : 'off');
	$("#txtMax").val(item.Maximo);
	$("#txtMin").val(item.Minimo);
	$("#txtCurrency").val(item.MonedasID);
	$("#chbOutdated").prop('checked', (item.Obsoleto === 1) ? true : false);
	$('#chbOutdated').bootstrapToggle((item.Obsoleto === 1) ? 'on' : 'off');
	$("#txtSupplier").val(item.ProveedoresID);
	$("#txtIEPS").val(item.PtjeIeps);
	$("#txtIVA").val(item.PtjeIva);
	$("#txtReorder").val(item.Reorden);
	$("#txtDeliveryTime").val(item.TiempoDeEntrega);
	$("#txtLocation").val(item.Ubicacion);
	$("#txtUM").val(item.UnidadesDeMedidaID);
	$("#chbActive").prop('checked', (item.Activo === 1) ? true : false);
	$('#chbActive').bootstrapToggle((item.Activo === 1) ? 'on' : 'off');

	$("#previewImg").attr("src", item.Imagen);
	$("#frmcaptura").modal("show");
}

function eliminar(item) {
	if (confirm('Desea eliminar el articulo:' + item.Nombre)) {
		$("#loading").show();

		$.ajax({
			url: "/Items/Delete",
			data: { id: item.ArticulosID },
			type: 'POST'
		}).done(function (data) {
			$("#loading").hide();

			if (data.Result == "OK") {
				$("#avisoS2").html("Eliminado correctamente");
				$("#alertaSuccess2").fadeTo(2000, 500).slideUp(500, function () {
					$("#alertaSuccess2").slideUp(500);
				});
				LlenaGrid();
			}
		}).fail(function (x, y, z) {
			$("#avisoD2").html(z);
			$("#alertaDanger2").fadeTo(2000, 500).slideUp(500, function () {
				$("#alertaDanger2").slideUp(500);
			});

		});
	};
}

function limpiaCajas() {
	$("#itemForm").trigger("reset");
}

$("#btnCerrar").click(function () {
	Cerrar();
});

function Cerrar() {
	$("#frmcaptura").modal("hide");
	LlenaGrid();
};

function GetCatalogs() {
	$("#loading").show();

	$.ajax({
		url: "/Catalogs/Grid",
		data: {},
		type: 'POST'
	}).done(function (data) {
		for (const item of data.Families) {
			$('#txtFamily').append($('<option>', {
				value: item.Id,
				text: item.Description
			}));
		};

		for (const item of data.Currencies) {
			$('#txtCurrency').append($('<option>', {
				value: item.Id,
				text: item.Description
			}));
		};

		for (const item of data.Suppliers) {
			$('#txtSupplier').append($('<option>', {
				value: item.Id,
				text: item.Description
			}));
		};

		for (const item of data.UM) {
			$('#txtUM').append($('<option>', {
				value: item.Id,
				text: item.Description
			}));
		};
	}).fail(function (x, y, z) {
	});
};

function showPreviewImage(event) {
	var reader = new FileReader();
	reader.onload = function () {
		var output = document.getElementById("previewImg");
		output.src = reader.result;
	};
	reader.readAsDataURL(event.target.files[0]);
}