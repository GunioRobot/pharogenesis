inspectIt: characterStream 
	"Inspect the selection -- invoked via cmd-i.  If there is no current selection, use the current line."

	sensor keyboard.		"flush character"
	self inspectIt.
	^ true