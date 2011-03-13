newMorphicOn: aPasteUpOrNil

	| newProject |

	newProject := self basicNew initMorphic.
	self addingProject: newProject.
	aPasteUpOrNil ifNotNil: [newProject installPasteUpAsWorld: aPasteUpOrNil].
	newProject createViewIfAppropriate.
	^newProject
