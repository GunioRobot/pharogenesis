showRegularDiffs: aBoolean
	"Set whether I'm showing regular diffs as indicated"

	self showingRegularDiffs
		ifFalse:
			[aBoolean ifTrue:
				[contentsSymbol _ #showDiffs]]
		ifTrue:
			[aBoolean ifFalse:
				[contentsSymbol _ #source]].
	self setContentsToForceRefetch.
	self contentsChanged