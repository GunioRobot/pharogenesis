typeForSlot: aSlotName
	"Answer the data type for values of the instance variable of the given name"

	(self slotInfo includesKey: aSlotName) ifTrue: [^ (self slotInfoAt: aSlotName) type].
	^ (ScriptingSystem typeForSystemSlotNamed: aSlotName)
		ifNil:
			[self error: 'no type for slot named ', aSlotName]