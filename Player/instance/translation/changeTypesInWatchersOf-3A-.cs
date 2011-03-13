changeTypesInWatchersOf: slotName
	"The type of a variable has changed; adjust watchers to that fact."

	| aGetter newWatcher |
	aGetter := Utilities getterSelectorFor: slotName.
	self allPossibleWatchersFromWorld do: [:aWatcher |
		(aWatcher getSelector = aGetter) ifTrue:
			[(aWatcher ownerThatIsA: WatcherWrapper) ifNotNilDo:
				[:aWrapper |
					newWatcher := (aWrapper submorphs size = 1)
						ifTrue:
							[WatcherWrapper new unlabeledForPlayer: self getter: aGetter]
						ifFalse:
							[WatcherWrapper new fancyForPlayer: self getter: aGetter].
					newWatcher position: aWatcher position.
					aWrapper owner replaceSubmorph: aWrapper by: newWatcher]]]
