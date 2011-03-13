sizeForValue: encoder
	| index |
	(key isVariableBinding and:[key isSpecialReadBinding]) 
		ifFalse:[^super sizeForValue: encoder].
	code < 0 ifTrue:[
		index := self index.
		code := self code: index type: LdLitType].
	readNode := encoder encodeSelector: #value.
	^(readNode size: encoder args: 0 super: false) + (super sizeForValue: encoder)