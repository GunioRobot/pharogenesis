storeOn: aStream
	aStream nextPutAll: '(Note new;'.
	aStream nextPutAll: 'author: ',self author storeString,';'.
	aStream nextPutAll: 'text: ',self text storeString,';'.
	aStream nextPutAll: 'parent: ',self parent storeString,';'.
	aStream nextPutAll: 'timestamp: ',self timestamp storeString,';'.
	aStream nextPutAll: 'title: ',self title storeString,';'.
	aStream nextPutAll: 'url: ',self url storeString,';'.
	aStream nextPutAll: 'yourself)'.