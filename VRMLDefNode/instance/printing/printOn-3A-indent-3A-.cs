printOn: aVRMLStream indent: aLevel

	aVRMLStream 
		nextPutAll: 'DEF ';
		nextPutAll: name;
		space.
	node printOn: aVRMLStream indent: aLevel.