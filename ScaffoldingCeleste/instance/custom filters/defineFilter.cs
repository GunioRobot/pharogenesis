defineFilter
	| filterName |
	mailDB ifNil: [ ^self ].
	filterName _ FillInTheBlank request: 'Filter name?'.
	filterName isEmpty ifTrue: [^ ''].
	^self editFilterNamed: filterName 
