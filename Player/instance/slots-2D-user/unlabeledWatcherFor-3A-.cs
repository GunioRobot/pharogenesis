unlabeledWatcherFor: aGetter
	"Answer an unnlabeled readout for viewing a numeric-valued slot of mine"

	| aWatcher info anInterface watcherWording itsType vocab aSetter |
	info _ self slotInfoForGetter: aGetter.
	info ifNotNil:
			[itsType _ info type.
			watcherWording _ Utilities inherentSelectorForGetter: aGetter.
			aSetter _ Utilities setterSelectorFor: watcherWording]
		ifNil:
			[anInterface _Vocabulary eToyVocabulary methodInterfaceAt: aGetter ifAbsent: [nil].
			anInterface
				ifNotNil:
					[itsType _ anInterface resultType.
					aSetter _ anInterface companionSetterSelector]
				ifNil:
					[itsType _ #Unknown.
					aSetter _ nil].
			watcherWording _ anInterface ifNotNil: [anInterface wording] ifNil: ['*']].
	vocab _ Vocabulary vocabularyForType: itsType.
	aWatcher _ vocab updatingTileForTarget: self partName: watcherWording getter: aGetter setter: aSetter.

	aWatcher setNameTo: (self externalName, '''s ', watcherWording).
	aWatcher minHeight: (vocab wantsArrowsOnTiles ifTrue: [22] ifFalse: [14]).
	^ aWatcher