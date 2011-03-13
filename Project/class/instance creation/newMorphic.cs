newMorphic
	| new |
	"ProjectView open: Project newMorphic"

	new _ self basicNew.
	self addingProject: new.
	new initMorphic.
	^new