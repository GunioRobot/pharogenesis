toggleColorPrint
	"Toggle whether color-print is in effect in the code pane"

	self restoreTextualCodingPane.
	self okToChange ifTrue:
		[self showingColorPrint
			ifTrue:
				[contentsSymbol _ #source]
			ifFalse:
				[contentsSymbol _ #colorPrint].
		self setContentsToForceRefetch.
		self contentsChanged]

