step
	| action |
	action _ self scrollBarAction.
	action ifNotNil:[self perform: action].