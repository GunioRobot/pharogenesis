largeTilesString

	^ (myProject parameterAt: #largeTiles ifAbsent: [false]) not
		ifTrue: ['<yes>large tiles']
		ifFalse: ['<no>large tiles']