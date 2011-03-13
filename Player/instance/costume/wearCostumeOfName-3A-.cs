wearCostumeOfName: aName
	| classToUse |
	classToUse _ Smalltalk at: (aName, 'Morph') asSymbol ifAbsent: 
		[Smalltalk at: aName asSymbol].
	self wearCostumeOfClass: classToUse