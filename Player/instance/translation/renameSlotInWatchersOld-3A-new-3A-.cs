renameSlotInWatchersOld: oldName new: newName
	"A variable has been renamed; get all relevant extant watchers updated.  All this assumed to be happening in the ActiveWorld"

	| wasStepping oldGetter |
	oldGetter _ Utilities getterSelectorFor: oldName.
	self allPossibleWatchersFromWorld do: [:aWatcher |
		(aWatcher getSelector = oldGetter) ifTrue:
			[(wasStepping _ aWatcher isStepping) ifTrue: [aWatcher stopStepping].
			aWatcher getSelector: (Utilities getterSelectorFor: newName).
			aWatcher putSelector ifNotNil:
				[aWatcher putSelector: (Utilities setterSelectorFor: newName)].
			((aWatcher isKindOf: UpdatingStringMorph) and: [aWatcher hasStructureOfComplexWatcher]) ifTrue:  "Old style fancy watcher"
				[aWatcher owner owner traverseRowTranslateSlotOld: oldName to: newName.
				(aWatcher target labelFromWatcher: aWatcher) contents: newName, ' = '].
			(aWatcher ownerThatIsA: WatcherWrapper) ifNotNilDo:
				[:wrapper | wrapper player: self variableName: newName].
			wasStepping ifTrue: [aWatcher startStepping]]]