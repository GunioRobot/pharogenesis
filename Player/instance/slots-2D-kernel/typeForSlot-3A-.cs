typeForSlot: aSlotName
	| infoDict |
	infoDict _ self slotInfo.
	(infoDict includesKey: aSlotName) ifTrue: [^ infoDict at: aSlotName].

	^ ScriptingSystem typeForSystemSlotNamed: aSlotName