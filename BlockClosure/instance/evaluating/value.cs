value
	"Activate the receiver, creating a closure activation (MethodContext)
	 whose closure is the receiver and whose caller is the sender of this message.
	 Supply the copied values to the activation as its arguments and copied temps.
	 Primitive. Optional (but you're going to want this for performance)."
	| newContext ncv |
	<primitive: 201>
	numArgs ~= 0 ifTrue:
		[self numArgsError: 0].
	newContext := self asContextWithSender: thisContext sender.
	(ncv := self numCopiedValues) > 0 ifTrue:
		[newContext stackp: ncv.
		1 to: ncv do: "nil basicSize = 0"
			[:i| newContext at: i put: (self at: i)]].
	thisContext privSender: newContext