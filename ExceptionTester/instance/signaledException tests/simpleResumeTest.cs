simpleResumeTest

	| it |
	[self doSomething.
	it := MyResumableTestError signal.
	it = 3 ifTrue: [self doSomethingElse]]
		on: MyResumableTestError
		do:
			[:ex |
			self doYetAnotherThing.
			ex resume: 3]