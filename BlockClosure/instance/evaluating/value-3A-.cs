value: anArg
	"Activate the receiver, creating a closure activation (MethodContext)
	 whose closure is the receiver and whose caller is the sender of this message.
	 Supply the argument and copied values to the activation as its arguments and copied temps.
	 Primitive. Optional (but you're going to want this for performance)."
	| newContext ncv |
	<primitive: 202>
	numArgs ~= 1 ifTrue:
		[self numArgsError: 1].
	newContext := self asContextWithSender: thisContext sender.
	ncv := self numCopiedValues.
	newContext stackp: ncv + 1.
	newContext at: 1 put: anArg.
	1 to: ncv do:
		[:i| newContext at: i + 1 put: (self at: i)].
	thisContext privSender: newContext