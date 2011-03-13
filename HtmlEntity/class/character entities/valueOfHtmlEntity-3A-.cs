valueOfHtmlEntity: specialEntity
	^Character value: (ReverseCharacterEntities at: specialEntity ifAbsent:
		[(specialEntity beginsWith: '#') ifTrue:
			[(specialEntity copyFrom: 2 to: specialEntity size) asNumber]
			ifFalse: [^nil]])
