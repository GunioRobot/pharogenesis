printExternOn: aVRMLStream indent: aLevel
	aVRMLStream 
		nextPutAll: self attributeClass; 
		space; 
		nextPutAll: self type; 
		space;
		nextPutAll: self name;
		crtab: aLevel.
