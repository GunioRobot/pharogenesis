printOn: aStream indent: aLevel
	aStream 
		nextPutAll:'PROTO ';
		nextPutAll: self nodeSpec name;
		nextPutAll:' [';
		crtab: aLevel+1.
	self nodeSpec attributes do:[:attr|
		attr printOn: aStream indent: aLevel+1.
	].
	aStream nextPutAll:'] {'.
	aStream crtab: aLevel.
	self protoValues do:[:value|
		value printOn: aStream indent: aLevel+1.
		aStream crtab: aLevel.
	].
	aStream nextPut:$}.
