addInstanceVariable
	| itsName initialValue typeChosen suggestedNames usedNames initialAnswer setterSelector |
	suggestedNames _ #('cargo' 'speed' 'weight' 'mzee' 'friml' 'verp' 'znak').
	usedNames _ self class instVarNames.
	initialAnswer _ suggestedNames detect: [:aName |  (usedNames includes: aName) not] ifNone:
		[Utilities keyLike: 'var1'  satisfying: [:aKey | (usedNames includes: aKey) not]].

	itsName _ FillInTheBlank request: 'name for new inst var: ' initialAnswer: initialAnswer.
 	itsName size == 0 ifTrue: [^ self].
	(Utilities isLegalInstVarName: itsName) ifFalse: [^ self inform: 'sorry, illegal name, try again.'].
	itsName _ itsName asSymbol.
	(self class allInstVarNames includes: itsName) ifTrue: [^ self inform: 'that name is already used.'].
	typeChosen _ self initialTypeForSlotNamed: itsName.
	self slotInfo at: itsName put: typeChosen.
	initialValue _ self initialValueForSlotOfType: typeChosen.
	self addInstanceVarNamed: itsName withValue: initialValue.
	self compileAccessorsFor: itsName.
	setterSelector _ Utilities setterSelectorFor: itsName.
	(self class allInstances copyWithout: self) do:
		[:anInstance | anInstance perform: setterSelector with: initialValue].
	self updateAllViewers