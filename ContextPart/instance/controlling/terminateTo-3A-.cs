terminateTo: previousContext
	"Terminate all the Contexts between me and previousContext, if previousContext is on my Context stack. Make previousContext my sender."

	| currentContext sendingContext |
	<primitive: 196>
	(self hasSender: previousContext) ifTrue: [
		currentContext _ sender.
		[currentContext == previousContext] whileFalse: [
			sendingContext _ currentContext sender.
			currentContext terminate.
			currentContext _ sendingContext]].
	sender _ previousContext