loadProject
	| stdFileMenuResult fileStream |
	"Put up a Menu and let the user choose a '.project' file to load.  Create a thumbnail and jump into the project."

	Smalltalk verifyMorphicAvailability ifFalse: [^ self].

	Smalltalk isMorphic ifFalse: [^ self inform:
		'Later, allow jumping from MVC to Morphic Projects.'].
	stdFileMenuResult _ ((StandardFileMenu new) pattern: '*.project'; 
		oldFileFrom: FileDirectory default ) 
			startUpWithCaption: 'Select a File:'.
	stdFileMenuResult ifNil: [^ nil].
	fileStream _ stdFileMenuResult directory oldFileNamed: stdFileMenuResult name.
	ProjectViewMorph openFromFile: fileStream