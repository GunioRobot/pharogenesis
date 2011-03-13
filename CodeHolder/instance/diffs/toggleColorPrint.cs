toggleColorPrint
	"Toggle whether color-print is in effect in the code pane"

	self restoreTextualCodingPane.
	self okToChange ifTrue:
		[self showingColorPrint
			ifTrue:
				[contentsSymbol := #source]
			ifFalse:
				[contentsSymbol := #colorPrint].
		self setContentsToForceRefetch.
		self contentsChanged]

