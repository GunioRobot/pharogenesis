toggleAltSyntax
	"Toggle the setting of the showingAltSyntax flag, unless there are unsubmitted edits that the user declines to discard"

	| wasShowing |
	self okToChange ifTrue:
		[wasShowing _ self showingAltSyntax.
		self restoreTextualCodingPane.
		self showAltSyntax: wasShowing not.
		self setContentsToForceRefetch.
		self contentsChanged]

