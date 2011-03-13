openMorphicProject
	"Open a morphic project from within a MVC project"
	Smalltalk verifyMorphicAvailability ifFalse: [^ self].
	ProjectView open: Project newMorphic.
