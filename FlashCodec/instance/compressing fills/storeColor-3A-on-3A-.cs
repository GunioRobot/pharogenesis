storeColor: color on: aStream
	| pv |
	pv _ color pixelWordForDepth: 32.
	aStream 
		nextPut: (pv digitAt: 1) asCharacter;
		nextPut: (pv digitAt: 2) asCharacter;
		nextPut: (pv digitAt: 3) asCharacter;
		nextPut: (pv digitAt: 4) asCharacter.

