simpleOuterTest
	"uses #resume"

	[[self doSomething.
	MyTestNotification signal.
	self doSomethingElse]
		on: MyTestNotification
		do: [:ex | ex outer]]
				on: MyTestNotification
				do: [:ex | self doYetAnotherThing. ex resume]