typeForSlot: aSlotName vocabulary: aVocabulary
	"Answer the data type for values of the instance variable of the given name.  Presently has no senders but retained for a while..."

	| getter inherentSelector |
	inherentSelector _ Utilities inherentSelectorForGetter: aSlotName.
	(self slotInfo includesKey: inherentSelector) ifTrue: [^ (self slotInfoAt: inherentSelector) type].
	getter _ (aSlotName beginsWith: 'get')
		ifTrue:
			[aSlotName]
		ifFalse:
			[Utilities getterSelectorFor: aSlotName].
	^ (aVocabulary methodInterfaceAt: getter ifAbsent: [self error: 'Unknown slot name: ', aSlotName]) resultType