printOn: aStream indent: level 
	aStream withAttribute: (TextColor color: Color blue)
			do: [aStream nextPutAll: name]