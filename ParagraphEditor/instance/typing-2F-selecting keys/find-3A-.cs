find: characterStream
	"Prompt the user for what to find, then find it, searching from the current selection onward.  1/24/96 sw"

	self closeTypeIn: characterStream.
	self find.
	^ true