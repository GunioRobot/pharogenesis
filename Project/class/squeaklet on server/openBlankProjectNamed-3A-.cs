openBlankProjectNamed: projName

	| proj projViewer |

	proj _ Project newMorphicOn: nil.
	proj changeSet name: projName.
	proj world addMorph: (
		TextMorph new 
			beAllFont: ((TextStyle default fontOfSize: 26) emphasized: 1);
			color: Color red;
			contents: 'Welcome to a new project - ',projName
	).
	CurrentProjectRefactoring currentBeParentTo: proj.
	projViewer _ (CurrentProject findProjectView: projName) ifNil: [^proj].
	(projViewer owner isSystemWindow) ifTrue: [
			projViewer owner model: proj].
	^ projViewer project: proj