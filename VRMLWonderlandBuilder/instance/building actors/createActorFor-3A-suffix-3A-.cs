createActorFor: aMesh suffix: aString
	^self createActorFor: aMesh
			name: (attributes at: #currentName ifAbsent:['unnamed'])
			suffix: aString