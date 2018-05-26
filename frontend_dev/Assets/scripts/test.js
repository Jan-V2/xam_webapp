
count = 0;
$("#counter_add").click(function (event) {
	console.log("called 1");
	location.href = "backend:bla";
});

function counter_update() {
	console.log("called 2");
	count++;
	$("#counter").html(count);
}