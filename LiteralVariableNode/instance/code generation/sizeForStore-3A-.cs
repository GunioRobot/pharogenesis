sizeForStore: encoder
	| index |
	(key isVariableBinding and:[key isSpecialWriteBinding]) 
		ifFalse:[^super sizeForStore: encoder].
	code < 0 ifTrue:[
		index := self index.
		code := self code: index type: LdLitType].
	writeNode := encoder encodeSelector: #value:.
	^(writeNode size: encoder args: 1 super: false) + (super sizeForValue: encoder)