var detalle = [];
var tableRow;
var index;

var IID;  //Se usa para evaluar sí están editando o nuevo (0)


$(document).ready(function () {
	LlenaGrid();
});

function LlenaGrid() {
	$("#loading").show();

	$.ajax({
		url: "/Lineas/Grid",
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
	$('#example').DataTable({
		language: esLanguage
	}).rows().remove().draw();  //Limpia la tabla x
	for (var i = 0; i < data.lineas.length; i++) {
		var columnas = [
			data.lineas[i].Linea,
			data.lineas[i].Des,
			'<button class="btnEliminaDetalle" style="border:none;" onclick="editar(/' + data.lineas[i].Linea + '/,/' + data.lineas[i].Des + '/)"><img src="../Content/Imagenes/edit.svg" height="10" width="10" /></button>',
			'<button class="btnEliminaDetalle" style="border:none;" onclick="eliminar(/' + data.lineas[i].Linea + '/)"><img src="../Content/Imagenes/delete.svg" height="10" width="10" /></button>'
		];

		var rowIndex = $('#example').dataTable().fnAddData(columnas);  //Agrega al DOM
		var row = $('#example').dataTable().fnGetNodes(rowIndex);
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



	var des = $("#txtDes").val();
	if (des == "" || des == null) {
		$("#avisoD").html("Capture la descripción");
		$("#alertaDanger").fadeTo(2000, 500).slideUp(500, function () {
			$("#alertaDanger").slideUp(500);
		});
		return;
	}

	var id = IID;

	$.ajax({
		url: "../Lineas/Guardar",
		data: { ID: id, Des: des },
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

function editar(id, des) {
	let strID = id.toString();
	strID = strID.replaceAll("/", "");

	let strDes = des.toString();
	strDes = strDes.replaceAll("/", "");

	IID = strID;


	$("#txtDes").val(strDes);

	$("#frmcaptura").modal("show");

}
function eliminar(id) {
	let strID = id.toString();
	strID = strID.replaceAll("/", "");

	if (confirm('Desea eliminar la línea:' + strID)) {
		$("#loading").show();

		$.ajax({
			url: "/Lineas/Eliminar",
			data: { ID: strID },
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
	IID = 0;
	$("#txtDes").val('');
}


$("#btnCerrar").click(function () {
	Cerrar();
});

function Cerrar() {
	$("#frmcaptura").modal("hide");
	LlenaGrid();
}




