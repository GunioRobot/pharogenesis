pop: nItems
	"Note: May be called by translated primitive code."

	self setStackPointer: (self stackPointer - (nItems*4)).