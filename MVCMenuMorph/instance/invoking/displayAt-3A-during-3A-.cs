displayAt: aPoint during: aBlock
	"Add this menu to the Morphic world during the execution of the given block."

	Smalltalk isMorphic ifFalse: [^ self].

	Display getCurrentMorphicWorld addMorph: self centeredNear: aPoint.
	self world displayWorld.  "show myself"
	aBlock value.
	self delete