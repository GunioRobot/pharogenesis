showingDiffsString
	"Answer a string representing whether I'm showing diffs.  Not sent any more but retained so that prexisting buttons that sent this will not raise errors."

	^ (self showingRegularDiffs
		ifTrue:
			['<yes>']
		ifFalse:
			['<no>']), 'showDiffs'