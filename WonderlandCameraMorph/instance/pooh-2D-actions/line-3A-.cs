line: newEvent
	| type |
	type _ newEvent getMorphicEvent type.
	self perform: (type, 'Line:') asSymbol with: newEvent
