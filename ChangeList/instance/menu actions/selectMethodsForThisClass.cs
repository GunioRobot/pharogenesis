selectMethodsForThisClass
	| name |
	self currentChange ifNil: [ ^self ].
	name _ self currentChange methodClassName.
	name ifNil: [ ^self ].
	^self selectSuchThat: [ :change |
		change methodClassName = name ].