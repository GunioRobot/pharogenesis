printOn: aStream
	aStream 
		"nextPutAll: self class name;
		nextPut:$(;"
		nextPut:$[;
		print: attrClass;
		nextPutAll:'] ';
		print: type;
		space;
		print: name;
		space.
	value isCollection
		ifTrue:[aStream print: value asArray]
		ifFalse:[aStream print: value].
