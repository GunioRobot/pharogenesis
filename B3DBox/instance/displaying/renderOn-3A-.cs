renderOn: aRenderer
	"Note: The use of BoxColors is an example for pre-lighting."
	1 to: 6 do:[:i|
		"Enable simple additive computation of box colors.
		Note: This must be turned on on per-primitive basis."
		aRenderer
			trackEmissionColor: true;		"Turn on pre-lit colors"
			normal: (BoxNormals at: i);
			color: (BoxColors at: i);		"Set pre-lit color per polygon"
			drawPolygonAfter:[
				aRenderer
					texCoords: (vertices at: ((BoxFaceIndexes at: i) at: 1));
					vertex: (vertices at: ((BoxFaceIndexes at: i) at: 1));
					texCoords: (vertices at: ((BoxFaceIndexes at: i) at: 2));
					vertex: (vertices at: ((BoxFaceIndexes at: i) at: 2));
					texCoords: (vertices at: ((BoxFaceIndexes at: i) at: 3));
					vertex: (vertices at: ((BoxFaceIndexes at: i) at: 3));
					texCoords: (vertices at: ((BoxFaceIndexes at: i) at: 4));
					vertex: (vertices at: ((BoxFaceIndexes at: i) at: 4)).
			].
	].