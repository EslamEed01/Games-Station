//$(document).ready(function () {
//	$('#Cover').on('change', function () {
//		$('.cover-preview').attr('src', window.URL.createObjectURL(this.files[0])).removeClass('d-none')

//	});
//}
//);

//$(document).ready(function () {
//    $('#Cover').on('change', function () {
//        // Check if a file has been selected
//        if (this.files && this.files[0]) {
//            // Create a URL for the selected file
//            var objectURL = window.URL.createObjectURL(this.files[0]);

//            // Set the preview image source
//            $('.cover-preview').attr('src', objectURL).removeClass('d-none');

//            // Optional: Revoke the object URL after it's used to free up memory
//            // You may want to do this in a different part of your code, e.g., when the image is removed or when the user uploads a new file.
//            // window.URL.revokeObjectURL(objectURL);
//        }
//    });
//});

document.addEventListener('DOMContentLoaded', function () {
    var coverInput = document.getElementById('Cover');
    if (coverInput) {
        coverInput.addEventListener('change', function () {
            var preview = document.querySelector('.cover-preview');
            if (preview) {
                preview.src = window.URL.createObjectURL(this.files[0]);
                preview.classList.remove('d-none');
            } else {
                console.error('Element with class "cover-preview" not found.');
            }
        });
    } else {
        console.error('Element with ID "Cover" not found.');
    }
});

