addSlotNamedLike: suggestedName withValue: aValue
	| otherNames numericSuffix nameToUse  stem itsInfo |
	stem _ suggestedName first asLowercase asString , suggestedName allButFirst.
	stem _ stem stemAndNumericSuffix first.
	nameToUse _ stem.
	otherNames _ self class allInstVarNames.
	numericSuffix _ 1.
	[otherNames includes: nameToUse]
		whileTrue: [numericSuffix _ numericSuffix + 1. (nameToUse _ stem, numericSuffix printString)].
	self class addInstVarName: nameToUse.
	self instVarAt: self class instSize put: aValue.  "Assumes added as last field"
	self class compileAccessorsFor: nameToUse.
	itsInfo _ SlotInformation new initialize type: aValue basicType.
	self slotInfo at: nameToUse asSymbol put: itsInfo.
	^ nameToUse