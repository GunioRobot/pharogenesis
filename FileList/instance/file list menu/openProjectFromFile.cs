openProjectFromFile
	"Reconstitute a Morph from the selected file, presumed to be represent
	a Morph saved via the SmartRefStream mechanism, and open it in an
	appropriate Morphic world."

 	| preStream |
	Smalltalk verifyMorphicAvailability ifFalse: [^ self].
	Smalltalk isMorphic ifFalse: [^ self inform: 
			'Later, allow jumping from MVC to Morphic Projects.'].
	preStream _ directory oldFileNamed: self fullName.
	ProjectViewMorph openFromFile: preStream