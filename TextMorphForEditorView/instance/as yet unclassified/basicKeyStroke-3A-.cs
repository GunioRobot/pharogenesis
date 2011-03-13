basicKeyStroke: evt
	"Do the key stroke and check to see if it should be accepted."

	super keyStroke: evt.
	self autoAccept
		ifTrue: [self editView hasUnacceptedEdits ifTrue: [self editor accept]]