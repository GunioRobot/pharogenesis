readFrom: file
	"Read the receiver from the file as two forms."
	theForm _ Form new readFrom: file.
	mask _ Form new readFrom: file.

"For compatibility with old OpaqueForms that are files, only read what they have."
"  nil allowed also in these fields.
	transparentPixelValue _ Integer readFrom: file.	
	colorMap _ Array readFrom: file.	
	rawColorMap _ Bitmap readFrom: file.	
"