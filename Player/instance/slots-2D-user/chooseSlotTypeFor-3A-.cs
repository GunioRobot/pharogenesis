chooseSlotTypeFor: aGetter
	"Let the user designate a type for the slot associated with the given getter"

	| typeChoices typeChosen slotName |
	slotName _ Utilities inherentSelectorForGetter: aGetter.
	typeChoices _ Vocabulary typeChoices.
	typeChosen _ (SelectionMenu labelList: (typeChoices collect: [:t | t translated]) lines: #() selections: typeChoices) startUpWithCaption: 
		('Choose the TYPE
for ' translated, slotName, '
(currently ' translated, (self slotInfoAt: slotName) type translated, ')').
	typeChosen isEmptyOrNil ifTrue: [^ self].
	(self typeForSlot: slotName) capitalized = typeChosen ifTrue: [^ self].

	(self slotInfoAt: slotName) type: typeChosen.
	self class allInstancesDo:   "allSubInstancesDo:"
		[:anInst | anInst instVarNamed: slotName asString put: 
			(anInst valueOfType: typeChosen from: (anInst instVarNamed: slotName))].
	self updateAllViewers.	"does siblings too"
