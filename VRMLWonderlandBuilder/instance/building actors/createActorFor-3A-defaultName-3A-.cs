createActorFor: aMesh defaultName: aString
	^self createActorFor: aMesh
			name: (attributes at: #currentName ifAbsent:[aString])
			suffix: ''