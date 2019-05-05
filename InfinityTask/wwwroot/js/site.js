// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Ajax call for a link
$("a[ajax-poziv='da']").click(function (event) {
	$(this).attr("ajax-poziv", "dodan");
	event.preventDefault();
	var url = $(this).attr("ajax-url");
	var divZaRezultat = $(this).attr("ajax-rezultat");
	$(this).show();
	$.ajax({
		type: "GET",
		url: url,
		success:
			function (data) {
				
				$("#" + divZaRezultat).html(data);
			}
	});


});
$("#AjaxFormButton").click(function() {
	$("#DivBackground").show();
	$("#AjaxForma").show();
});
$("#ButtonAjaxEdit").click(function() {
	$("#DivBackground").show();
	$("#AjaxForma").show();
});
$("form[ajax-poziv='da']").submit(function (event) {
	$(this).attr("ajax-poziv", "dodan");
	event.preventDefault();
	var url = $(this).attr("ajax-url");
	
	var divZaRezultat = $(this).attr("ajax-rezultat");

	for (instance in CKEDITOR.instances) {
		CKEDITOR.instances[instance].updateElement();
	}
	var form = $(this);

	$.ajax({
		type: "POST",
		url: url,
		data: form.serialize(),
		success: function (data) {
			console.log(divZaRezultat);
			$("#" + divZaRezultat).html(data);
		}
	});
});
$("#ButtonCancel").click(function() {
	$("#AjaxForma").hide();
	$("#DivBackground").hide();

});
$("form[ajax-search='yes']").keyup(function (event) {
	$(this).attr("ajax-search", "add");
	event.preventDefault();
	var url = $(this).attr("ajax-url");

	var divZaRezultat = $(this).attr("ajax-result");

	
	
	var form = $(this);

	$.ajax({
		type: "POST",
		url: url,
		data: form.serialize(),
		success: function (data) {


			console.log(divZaRezultat);
			$("#" + divZaRezultat).html(data);
		}
	});
});
