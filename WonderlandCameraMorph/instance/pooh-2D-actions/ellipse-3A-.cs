ellipse: newEvent
	| type |
	type _ newEvent getMorphicEvent type.
	self perform: (type, 'Ellipse:') asSymbol with: newEvent
