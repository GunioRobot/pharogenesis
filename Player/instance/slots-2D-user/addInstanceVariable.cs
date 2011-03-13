addInstanceVariable
	"Offer the user the opportunity to add an instance variable, and if he goes through with it, actually add it"

	| itsName initialValue typeChosen suggestedNames usedNames initialAnswer setterSelector originalString |
	suggestedNames _ #('cargo' 'speed' 'weight' 'mzee' 'friml' 'verp' 'znak').
	usedNames _ self class instVarNames.
	initialAnswer _ suggestedNames detect: [:aName |  (usedNames includes: aName) not] ifNone:
		[Utilities keyLike: 'var1'  satisfying: [:aKey | (usedNames includes: aKey) not]].

	originalString _ FillInTheBlank request: 'name for new inst var: ' initialAnswer: initialAnswer.
	itsName _ ScriptingSystem acceptableSlotNameFrom: originalString forSlotCurrentlyNamed: nil asSlotNameIn: self world: self costume world.

 	itsName size == 0 ifTrue: [^ self].	
	self assureUniClass.
	typeChosen _ self initialTypeForSlotNamed: itsName.
	self slotInfo at: itsName put: (SlotInformation new initialize type: typeChosen).
	initialValue _ self initialValueForSlotOfType: typeChosen.
	self addInstanceVarNamed: itsName withValue: initialValue.
	self class compileAccessorsFor: itsName.
	setterSelector _ Utilities setterSelectorFor: itsName.
	(self class allSubInstances copyWithout: self) do:
		[:anInstance | anInstance perform: setterSelector with: initialValue].
	self updateAllViewersAndForceToShow: #'instance variables'
