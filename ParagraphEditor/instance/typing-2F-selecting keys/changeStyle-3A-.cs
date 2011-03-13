changeStyle: characterStream 
	"Put up the style-change menu"

	self closeTypeIn: characterStream.
	self changeStyle.
	^ true