typeForSlot: aSlotName
	"Answer the data type for values of the instance variable of the given name"

	| getter |
	(self slotInfo includesKey: aSlotName) ifTrue: [^ (self slotInfoAt: aSlotName) type].
	getter _ (aSlotName beginsWith: 'get')
		ifTrue:
			[aSlotName]
		ifFalse:
			[Utilities getterSelectorFor: aSlotName].
	^ (self currentVocabulary methodInterfaceAt: getter ifAbsent: [self error: 'Unknown slot name: ', aSlotName]) resultType