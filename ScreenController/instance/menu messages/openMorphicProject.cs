openMorphicProject

	Smalltalk verifyMorphicAvailability ifFalse: [^ self].
	ProjectView open: Project newMorphic.
