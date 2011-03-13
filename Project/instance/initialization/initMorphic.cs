initMorphic

	"Written so that Morphic can still be removed."
	Smalltalk verifyMorphicAvailability ifFalse: [^ nil].
	self initialize.
	world _ PasteUpMorph newWorldForProject: self.

