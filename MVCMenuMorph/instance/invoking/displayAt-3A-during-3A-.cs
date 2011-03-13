displayAt: aPoint during: aBlock
	"Add this menu to the Morphic world during the execution of the given block."

	World ifNil: [^ self].
	World addMorph: self centeredNear: (aPoint - World viewBox origin).
	World doOneCycle.  "show myself"
	aBlock value.
	self delete.
