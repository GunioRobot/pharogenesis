togglePrettyPrint
	"Toggle whether pretty-print is in effectin the code pane"

	self restoreTextualCodingPane.
	self okToChange ifTrue:
		[self showingPrettyPrint
			ifTrue:
				[contentsSymbol _ #source]
			ifFalse:
				[contentsSymbol _ #prettyPrint].
		self setContentsToForceRefetch.
		self contentsChanged]

