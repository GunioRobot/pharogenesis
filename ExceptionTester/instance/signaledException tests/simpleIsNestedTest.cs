simpleIsNestedTest
	"uses resignalAs:"

	[self doSomething.
	MyTestError signal.
	self doSomethingElse]
		on: MyTestError
		do:
			[:ex |
			ex isNested "expecting to detect handler in #runTest:"
				ifTrue:
					[self doYetAnotherThing.
					ex resignalAs: MyTestNotification new]]