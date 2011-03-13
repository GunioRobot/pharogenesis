findAgain: characterStream 
	"Find the desired text again.  1/24/96 sw"

	self closeTypeIn: characterStream.
	self findAgain.
	^ true