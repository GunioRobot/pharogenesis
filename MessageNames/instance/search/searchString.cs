searchString
	"Answer the current searchString, initializing it if need be"

	| pane |
	searchString isEmptyOrNil ifTrue:
		[searchString := 'type here, then hit Search'.
		pane := self containingWindow findDeepSubmorphThat:
			[:m | m knownName = 'Search'] ifAbsent: ["this happens during window creation" ^ searchString].
			pane setText: searchString.
			pane setTextMorphToSelectAllOnMouseEnter.
			pane selectAll].
	^ searchString