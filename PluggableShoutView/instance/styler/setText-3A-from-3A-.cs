setText: textToAccept from: ctlr
	"Re-implemented to save an unstyled copy of textToAccept"
	
	self okToStyle ifFalse:[^super setText: textToAccept from: ctlr].
	unstyledAcceptText := styler unstyledTextFrom: textToAccept.
	[^super setText: unstyledAcceptText from: ctlr]
	ensure:[unstyledAcceptText := nil]