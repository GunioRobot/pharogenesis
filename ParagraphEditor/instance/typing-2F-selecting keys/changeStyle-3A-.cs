changeStyle: characterStream 
	"Put up the style-change menu"

	sensor keyboard.		"flush character"
	self closeTypeIn: characterStream.
	self changeStyle.
	^ true