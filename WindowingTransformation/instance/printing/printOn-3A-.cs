printOn: aStream 
	"Refer to the comment in Object|printOn:."

	aStream nextPutAll: self class name, ' scale: ';
		print: scale; nextPutAll: ' translation: ';
		print: translation