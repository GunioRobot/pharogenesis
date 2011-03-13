printOn: aStream
	"Print the receiver on aStream"

	super printOn: aStream.
	aStream nextPutAll: ' for #', selector asString