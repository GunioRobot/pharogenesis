printOn: aStream
	"Print the receiver on aStream"

	super printOn: aStream.
	aStream nextPutAll: ' (', self oopString, ') '.
	aStream nextPutAll: ' for #', selector asString