rect: newEvent
	| type |
	type _ newEvent getMorphicEvent type.
	self perform: (type, 'Rect:') asSymbol with: newEvent
