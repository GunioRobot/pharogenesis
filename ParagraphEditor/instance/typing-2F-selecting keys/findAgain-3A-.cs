findAgain: characterStream 
	"Find the desired text again.  1/24/96 sw"

	sensor keyboard.		"flush character"
	self closeTypeIn: characterStream.
	self findAgain.
	^ true