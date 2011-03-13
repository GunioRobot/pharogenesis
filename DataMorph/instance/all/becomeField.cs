becomeField
	| aStack slotNameChosen  |
	aStack _ self pasteUpMorph assuredCostumee.

	slotNameChosen _ aStack addSlotNamedLike: self externalName withValue: self valueFromContents.

	self getSelector: (Utilities getterSelectorFor: slotNameChosen).
	self putSelector: (Utilities setterSelectorFor: slotNameChosen).
	self target: aStack.
	status _ #field.
	aStack updateAllViewers