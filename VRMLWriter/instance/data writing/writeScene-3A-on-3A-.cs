writeScene: aScene on: aVRMLStream
	aVRMLStream nextPutAll:'#VRML V2.0 utf8'; cr.
	aScene nodes do:[:node| 
		node printOn: aVRMLStream indent: 0.
		aVRMLStream cr.].
	aScene actions keysAndValuesDo:[:fromName :outDict|
		outDict keysAndValuesDo:[:outEvt :toDict|
			toDict keysAndValuesDo:[:toName :inSet|
				inSet do:[:inEvt|
		aVRMLStream 
			nextPutAll:'ROUTE ';
			nextPutAll: fromName;
			nextPut:$.;
			nextPutAll: outEvt name;
			nextPutAll:' TO ';
			nextPutAll: toName;
			nextPut:$.;
			nextPutAll: inEvt name;
			cr]]]].