showDiffs: aBoolean
	"Set whether I'm showing diffs as indicated; use the global preference to determine which kind of diffs to institute."

	self showingAnyKindOfDiffs
		ifFalse:
			[aBoolean ifTrue:
				[contentsSymbol _ self defaultDiffsSymbol]]
		ifTrue:
			[aBoolean ifFalse:
				[contentsSymbol _ #source]].
	self setContentsToForceRefetch.
	self contentsChanged