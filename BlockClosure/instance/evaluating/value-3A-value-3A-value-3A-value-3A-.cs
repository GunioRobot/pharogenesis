value: firstArg value: secondArg value: thirdArg value: fourthArg
	"Activate the receiver, creating a closure activation (MethodContext)
	 whose closure is the receiver and whose caller is the sender of this message.
	 Supply the arguments and copied values to the activation as its arguments and copied temps.
	 Primitive. Optional (but you're going to want this for performance)."
	| newContext ncv |
	<primitive: 205>
	numArgs ~= 4 ifTrue:
		[self numArgsError: 4].
	newContext := self asContextWithSender: thisContext sender.
	ncv := self numCopiedValues.
	newContext stackp: ncv + 4.
	newContext at: 1 put: firstArg.
	newContext at: 2 put: secondArg.
	newContext at: 3 put: thirdArg.
	newContext at: 4 put: fourthArg.
	1 to: ncv do:
		[:i| newContext at: i + 4 put: (self at: i)].
	thisContext privSender: newContext