signal
	"Signal the occurrence of an exceptional condition."
	"Warning is overriding this and marking it private in order to get around an apparent contradiction within the ANSI specification:
		Warning>>defaultAction must give the user the option to 'abort the computation'.
		Warning is resumable.
		Exception>>signal must return to its caller if it reaches a defaultAction in the case of a resumable exception.
		Therefore, Warning needs to invoke a handler action from its defaultAction; that handler action would seem to be return:, but according to the spec, 'It is erroneous to directly or indirectly send this message from within a #defaultAction method  to the receiver of the #defaultAction method.'

We have chosen to support the apparently intended behavior of Warning, at the expense of introducing a mildly unpleasant hack - in case of an unhandled Warning, we determine whether the user has elected to continue or not.  In the latter case, this process needs to terminate immediately, without returning to the sender of #signal.  To accomplish this, we nil out the sender on the call stack, and then use MethodContext>>cannotReturn: to open a notifier and allow the environment to continue in use."

	| result |
	initialContext == nil ifTrue: [initialContext := thisContext sender].
	resignalException := nil.
	(self setHandlerFrom: initialContext) == nil
		ifTrue:
			[self defaultAction.
			"if user elected to continue the computation, execution did not reach this line"
			initialContext unwindTo: nil.
			thisContext terminateTo: nil]
		ifFalse:
			[result := self handlerAction.
			^resignalException == nil
				ifTrue: [result]
				ifFalse: [resignalException signal]]