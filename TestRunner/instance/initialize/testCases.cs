testCases

	Preferences testRunnerShowAbstractClasses ifTrue: [
			^ TestCase allSubclasses.
	].
	^ TestCase allSubclasses reject: [:cls | cls isAbstract]