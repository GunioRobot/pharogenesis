addInstanceVariableNamed: nameSymbol type: typeChosen value: aValue
	"Add an instance variable of the given name and type, and initialize it to have the given value"

	| initialValue setterSelector |
	self assureUniClass.
	self slotInfo at: nameSymbol put: (SlotInformation new initialize type: typeChosen).
	initialValue _ self initialValueForSlotOfType: typeChosen.
	self addInstanceVarNamed: nameSymbol withValue: aValue.
	self class compileAccessorsFor: nameSymbol.
	setterSelector _ Utilities setterSelectorFor: nameSymbol.
	(self class allSubInstances copyWithout: self) do:
		[:anInstance | anInstance perform: setterSelector with: initialValue].
	self updateAllViewersAndForceToShow: ScriptingSystem nameForInstanceVariablesCategory
