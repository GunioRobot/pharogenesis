exploreIt: characterStream 
	"Explore the selection -- invoked via cmd-shift-I.  If there is no current selection, use the current line."

	sensor keyboard.		"flush character"
	self terminateAndInitializeAround: [self exploreIt].
	^ true