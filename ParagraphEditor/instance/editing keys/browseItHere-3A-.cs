browseItHere: characterStream 
	"Triggered by Cmd-shift-B; browse the thing represented by the current selection, if plausible, in the receiver's own window.  3/1/96 sw"

	sensor keyboard.		"flush character"
	self browseItHere.
	^ true