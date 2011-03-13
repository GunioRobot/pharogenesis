methodNamesContainingIt: characterStream 
	"Triggered by Cmd-K; browse selectors containing the selection in their names.  8/11/96 sw"

	sensor keyboard.		"flush character"
	self methodNamesContainingIt.
	^ true