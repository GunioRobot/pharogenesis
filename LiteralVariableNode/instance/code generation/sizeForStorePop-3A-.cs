sizeForStorePop: encoder
	| index |
	(self key isVariableBinding and:[self key isSpecialWriteBinding]) 
		ifFalse:[^super sizeForStorePop: encoder].
	self code < 0 ifTrue:[
		index _ self index.
		self code: (self code: index type: LdLitType)].
	splNode _ encoder encodeSelector: #value:.
	^ (splNode size: encoder args: 1 super: false) + (super sizeForValue: encoder) + 1