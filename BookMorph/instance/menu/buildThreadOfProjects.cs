buildThreadOfProjects

	| thisPVM projectNames threadName |

	projectNames _ pages collect: [ :each |
		(thisPVM _ each findA: ProjectViewMorph) ifNil: [
			nil
		] ifNotNil: [
			{thisPVM project name}.
		].
	].
	projectNames _ projectNames reject: [ :each | each isNil].
	threadName _ FillInTheBlank 
		request: 'Please name this thread.' translated 
		initialAnswer: (
			self valueOfProperty: #nameOfThreadOfProjects ifAbsent: ['Projects on Parade' translated]
		).
	threadName isEmptyOrNil ifTrue: [^self].
	InternalThreadNavigationMorph 
		know: projectNames as: threadName;
		openThreadNamed: threadName atIndex: nil.
