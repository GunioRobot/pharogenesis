browseIt: characterStream 
	"Triggered by Cmd-B; browse the thing represented by the current selection, if plausible.  1/18/96 sw"

	sensor keyboard.		"flush character"
	self browseIt.
	^ true