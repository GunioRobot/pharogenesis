dragThroughOnDesktop: evt
	"Draw out a selection rectangle"
	| selection |

	"globalPt _ (self transformFrom: self world) localPointToGlobal: evt cursorPoint."
	selection _ SelectionMorph newBounds: (evt cursorPoint extent: 8@8).
	self addMorph: selection.
	^ selection extendByHandPlus: evt hand
