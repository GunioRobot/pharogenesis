printOn: aStream
	aStream
		nextPutAll: self class name;
		nextPut:$(;
		cr; nextPutAll:' r * '; print: rMul; nextPutAll:' + '; print: rAdd;
		cr; nextPutAll:' g * '; print: gMul; nextPutAll:' + '; print: gAdd;
		cr; nextPutAll:' b * '; print: bMul; nextPutAll:' + '; print: bAdd;
		cr; nextPutAll:' a * '; print: aMul; nextPutAll:' + '; print: aAdd;
		nextPut:$).