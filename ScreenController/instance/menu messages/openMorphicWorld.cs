openMorphicWorld 
	"Create and schedule a StringHolderView for use as a workspace."
	Smalltalk verifyMorphicAvailability ifFalse: [^ self].
	MorphWorldView openWorld.
