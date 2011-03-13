newMorphicOn: aPasteUpOrNil

	| newProject |

	newProject _ self basicNew initMorphic.
	self addingProject: newProject.
	aPasteUpOrNil ifNotNil: [newProject installPasteUpAsWorld: aPasteUpOrNil].
	newProject createViewIfAppropriate.
	^newProject
