printOn: aVRMLStream indent: aLevel

	aVRMLStream 
		nextPutAll: 'USE ';
		nextPutAll: name;
		space.