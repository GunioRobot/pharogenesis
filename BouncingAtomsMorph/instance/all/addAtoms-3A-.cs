addAtoms: n
	"Add a bunch of new atoms."

	| a |
	n timesRepeat: [
		a _ AtomMorph new.
		a randomPositionIn: bounds maxVelocity: 10.
		self addMorph: a].
	self stopStepping.