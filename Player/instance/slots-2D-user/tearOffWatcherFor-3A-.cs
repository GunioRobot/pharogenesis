tearOffWatcherFor: aSlotGetter
	"Tear off a simple textual watcher for the slot whose getter is provided"

	| aWatcher anInterface info isNumeric |

	info _ self slotInfoForGetter: aSlotGetter.
	info
		ifNotNil:
			[isNumeric _ info type == #Number]
		ifNil:
			[anInterface _ Vocabulary eToyVocabulary methodInterfaceAt: aSlotGetter ifAbsent: [nil].
			isNumeric _ anInterface notNil and: [anInterface resultType == #Number]].
	aWatcher _ UpdatingStringMorph new.
	
	aWatcher
		growable: true;
		getSelector: aSlotGetter;
		putSelector: (info notNil
			ifTrue:
				[ScriptingSystem setterSelectorForGetter: aSlotGetter]
			ifFalse:
				[anInterface companionSetterSelector]);
		setNameTo: (info notNil
			ifTrue:
				[Utilities inherentSelectorForGetter: aSlotGetter]
			ifFalse:
				[anInterface wording]);
 		target: self.
	isNumeric
		ifFalse:
			[aWatcher useStringFormat]
		ifTrue:
			[self setFloatPrecisionFor: aWatcher].
	aWatcher
		step;
		fitContents;
		openInHand