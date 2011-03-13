setVectorSlotTypeFor: slotName typeChosen: typeChosen

	| index initVar |
	index _ info at: slotName asSymbol.
	index = 0 ifTrue: [^ self].

	initVar _ self initialValueForSlotOfType: typeChosen.

	types at: index put: typeChosen.

	self compileAllAccessors.
	arrays at: index put: (self arrayForType: typeChosen).
	self perform: ('set', slotName capitalized, ':') asSymbol with: initVar.
