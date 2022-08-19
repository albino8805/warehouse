var detalle = [];
var tableRow;
var index;
var lines = [];

var IID;

$(document).ready(function () {
	LlenaGrid();
	GetLines();

	$("#familyForm").validate({
		lang: 'sp'
	});

	$("#frmcaptura").on('hidden.bs.modal', function (e) {
		limpiaCajas();
	});
});

function LlenaGrid() {
	$("#loading").show();

	$.ajax({
		url: "/Families/Grid",
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
	$('#tableData').DataTable().rows().remove().draw();  //Limpia la tabla x
	for (var i = 0; i < data.Families.length; i++) {
		var columnas = [
			data.Families[i].Description,
			data.Families[i].Family,
			data.Families[i].Line,
			"<button class='btnEliminaDetalle' style='border:none;' onclick='editar(" + JSON.stringify(data.Families[i]) + ")'><img src='../Content/Imagenes/edit.svg' height='10' width='10' /></button>",
			"<button class='btnEliminaDetalle' style='border:none;' onclick='eliminar(" + JSON.stringify(data.Families[i]) + ")'><img src='../Content/Imagenes/delete.svg' height='10' width='10' /></button>"
		];

		var rowIndex = $('#tableData').dataTable().fnAddData(columnas);  //Agrega al DOM
		var row = $('#tableData').dataTable().fnGetNodes(rowIndex);
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
	Guardar();
});

function Guardar() {
	if ($("#familyForm").valid()) {
		var family = $("#txtFamily").val();
		var des = $("#txtDes").val();
		var line = $("#txtLine").val();

		$.ajax({
			url: "../Families/Add",
			data: { family: family, description: des, line: line },
			type: 'POST'
		}).done(function (data) {
			$("#loading").hide();

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

function editar(family) {
	$("#txtFamily").val(family.Family);
	$("#txtDes").val(family.Description);
	$("#txtLine").val(family.Line);;

	$("#frmcaptura").modal("show");
}

function eliminar(family) {
	if (confirm('Desea eliminar la familia:' + family.Des)) {
		$("#loading").show();

		$.ajax({
			url: "/Families/Delete",
			data: { id: family.Familia },
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
	$("#familyForm").trigger("reset");
}

$("#btnCerrar").click(function () {
	Cerrar();
});

function Cerrar() {
	$("#frmcaptura").modal("hide");
	LlenaGrid();
};

function GetLines() {
	$("#loading").show();

	$.ajax({
		url: "/Lineas/Grid",
		data: {},
		type: 'POST'
	}).done(function (data) {
		for (const item of data.lineas) {
			$('#txtLine').append($('<option>', {
				value: item.Linea,
				text: item.Des
			}));
		}
	}).fail(function (x, y, z) {
	});
};




