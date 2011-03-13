newMorphic
	| new |
	"ProjectView open: Project newMorphic"

	new := self basicNew.
	self addingProject: new.
	new initMorphic.
	^new