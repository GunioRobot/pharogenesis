showPrettyDiffs: aBoolean
	"Set whether I'm showing pretty diffs as indicated"

	self showingPrettyDiffs
		ifFalse:
			[aBoolean ifTrue:
				[contentsSymbol _ #prettyDiffs]]
		ifTrue:
			[aBoolean ifFalse:
				[contentsSymbol _ #source]].
	self setContentsToForceRefetch.
	self contentsChanged