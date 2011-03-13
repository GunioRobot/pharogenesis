chooseSlotTypeFor: slotName
	| typeChoices typeChosen |
	typeChoices _ #(number player boolean color point string costume).
	typeChosen _ (SelectionMenu selections: typeChoices lines: #()) startUpWithCaption: 'Choose the TYPE
for ', slotName.
	(typeChosen size == 0) ifTrue: [^ self].
	(self typeForSlot: slotName) = typeChosen ifTrue: [^ self].

	self slotInfo at: slotName put: typeChosen.
	self class allInstancesDo:
		[:anInst | anInst instVarNamed: slotName asString put: 
			(anInst valueOfType: typeChosen from: (anInst instVarNamed: slotName)).
		anInst updateAllViewers]
