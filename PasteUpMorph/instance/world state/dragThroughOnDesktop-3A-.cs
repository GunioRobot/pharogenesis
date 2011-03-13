dragThroughOnDesktop: evt
	"Draw out a selection rectangle"
	| selection |
	selection _ SelectionMorph newBounds: (evt cursorPoint extent: 8@8).
	self addMorph: selection.
	^ selection extendByHand: evt hand
