labelString
	| label |
	label := self navigationPanel labelString.
	^label 
		ifNil: [self defaultLabel]
		ifNotNil: [self defaultLabel , ': ' , label]