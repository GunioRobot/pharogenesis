printOn: aStream 
	"Refer to the comment in Object|printOn:."

	aStream nextPutAll: '{'.
	aStream nextPutAll: ((ColoredCodeStream contents: [:strm | self printOn: strm indent: 0])
							asString).
	aStream nextPutAll: '}'