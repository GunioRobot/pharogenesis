value: firstArg value: secondArg
	"Activate the receiver, creating a closure activation (MethodContext)
	 whose closure is the receiver and whose caller is the sender of this message.
	 Supply the arguments and copied values to the activation as its arguments and copied temps.
	 Primitive. Optional (but you're going to want this for performance)."
	| newContext ncv |
	<primitive: 203>
	numArgs ~= 2 ifTrue:
		[self numArgsError: 2].
	newContext := self asContextWithSender: thisContext sender.
	ncv := self numCopiedValues.
	newContext stackp: ncv + 2.
	newContext at: 1 put: firstArg.
	newContext at: 2 put: secondArg.
	1 to: ncv do:
		[:i| newContext at: i + 2 put: (self at: i)].
	thisContext privSender: newContext