togglePlainSource
	"Toggle whether plain source shown in the code pane"
	
	| wasShowingPlainSource |
	self okToChange ifTrue:
		[wasShowingPlainSource _ self showingPlainSource.
		self restoreTextualCodingPane.
		wasShowingPlainSource
			ifTrue:
				[self showDocumentation: true]
			ifFalse:
				[contentsSymbol _ #source].
		self setContentsToForceRefetch.
		self changed: #contents]

