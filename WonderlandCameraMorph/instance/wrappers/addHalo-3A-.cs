addHalo: evt
	"Add a halo to an object"
	| actor wrapper root |
	self removeAllWrappers. "Get rid of them"
	evt == nil ifTrue:[^super addHalo: evt].
	actor _ myCamera pickAt: evt cursorPoint.
	actor == nil ifTrue:[^super addHalo: evt]. "Nothing hit"
	wrapper _ WonderlandWrapperMorph on: actor.
	root _ wrapper createHierarchy.
	root computeFullBounds: self.
	self addMorphFront: root.
	wrapper addHalo. "Add programatically"