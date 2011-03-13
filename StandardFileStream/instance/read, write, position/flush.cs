flush
	"In some OS's seeking to 0 and back will do a flush"
	| p |
	p _ self position.
	self position: 0; position: p