toggleDecompile
	"Toggle the setting of the showingDecompile flag, unless there are unsubmitted edits that the user declines to discard"

	| wasShowing |
	self okToChange ifTrue:
		[wasShowing _ self showingDecompile.
		self restoreTextualCodingPane.
		self showDecompile: wasShowing not.
		self setContentsToForceRefetch.
		self contentsChanged]

