selectAll: characterStream 
	"select everything, invoked by cmd-a.  1/17/96 sw"

	sensor keyboard.		"flush character"
	self closeTypeIn: characterStream.
	self selectFrom: 1 to: paragraph text string size.
	^ true