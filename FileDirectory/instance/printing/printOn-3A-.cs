printOn: aStream 
	"Refer to the comment in Object|printOn:."

	aStream nextPutAll: self class name.
	aStream nextPutAll: ' on '.
	pathName printOn: aStream.
