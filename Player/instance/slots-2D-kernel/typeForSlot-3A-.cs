typeForSlot: aSlotName
	(self slotInfo includesKey: aSlotName) ifTrue: [^ (self slotInfoAt: aSlotName) type].

	^ ScriptingSystem typeForSystemSlotNamed: aSlotName