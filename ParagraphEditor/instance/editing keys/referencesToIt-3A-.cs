referencesToIt: characterStream 
	"Triggered by Cmd-N; browse references to the current selection"

	sensor keyboard.		"flush character"
	self referencesToIt.
	^ true