implementorsOfIt: characterStream 
	"Triggered by Cmd-m; browse implementors of the selector represented by the current selection, if plausible. 2/1/96 sw"

	sensor keyboard.		"flush character"
	self implementorsOfIt.
	^ true