httpJpeg: url
	"Fetch the given URL, parse it using the JPEG reader, and return the resulting Form."

	| doc ggg |
	doc _ self httpGet: url.
	doc binary; reset.
	(ggg _ JPEGReadWriter new) setStream: doc.
	^ ggg nextImage.
