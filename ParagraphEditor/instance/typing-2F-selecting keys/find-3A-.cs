find: characterStream
	"Prompt the user for what to find, then find it, searching from the current selection onward.  1/24/96 sw"

	sensor keyboard.		"flush character"
	self closeTypeIn: characterStream.
	self find.
	^ true