printOn: aVRMLStream indent: aLevel
	| first |
	aVRMLStream 
		nextPutAll:'EXTERNPROTO ';
		nextPutAll: self nodeSpec name;
		nextPutAll:' [';
		crtab: aLevel+1.
	self nodeSpec attributes do:[:attr|
		attr printExternOn: aVRMLStream indent: aLevel+1.
	].
	aVRMLStream nextPutAll:']'.
	aVRMLStream crtab: aLevel;
		nextPut:$[; space.
	first := true.
	self urlList do:[:string|
		first ifFalse:[aVRMLStream crtab: aLevel].
		aVRMLStream writeString: string.
		first := false].
	aVRMLStream nextPut:$].
	aVRMLStream cr.