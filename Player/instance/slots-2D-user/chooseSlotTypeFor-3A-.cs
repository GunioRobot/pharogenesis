chooseSlotTypeFor: slotName
	| typeChoices typeChosen |
	self flag: #deferred.  "sound should be reinstated but too much difficulty at present"

	typeChoices _ #(number player boolean color string "sound point costume").
	typeChosen _ (SelectionMenu selections: typeChoices lines: #()) startUpWithCaption: 'Choose the TYPE
for ', slotName.
	typeChosen isEmptyOrNil ifTrue: [^ self].
	(self typeForSlot: slotName) = typeChosen ifTrue: [^ self].

	(self slotInfoAt: slotName) type: typeChosen.
	self class allInstancesDo:   "allSubInstancesDo:"
		[:anInst | anInst instVarNamed: slotName asString put: 
			(anInst valueOfType: typeChosen from: (anInst instVarNamed: slotName)).
		anInst updateAllViewers]
