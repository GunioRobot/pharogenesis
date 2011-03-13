ifFail: aOneArgBlock
	"Usage:
		answer _ [code to try] ifFail: [:aFailure | code to run instead].
	 'answer' will become the value of 'code to try', unless that code invokes
	 	(Failure name: #aName) propagate
	 or
	 	(Failure name: #aName value: anErrCode) propagate
	 in which case 'answer' will become the value of 'code to run instead'.

	 The first time 'propagate' is sent to a failure, three attributes of that failure
	 are determined:
		The 'instigator' of the failure is that Context executing 'ifFail:' whose
			receiver is the block whose evaluation called 'propagate'.
		The 'generator' of the failure is the instigator's receiver-block
			(the one whose evaluation called 'propagate').
		The 'handler' of the failure is the instigator's argument-block
			(the one that will be run because the generator failed).

	 Special things you can do in a handler are explained below.

	 You can access the 'name' and 'value' fields of aFailure.

	 You can create a new failure; it will run the handler of the next outer 'ifFail:'.

	 You can propagate a failure to the next outer 'ifFail:' with:
		aFailure propagate
	 You can alter the name or value of a failure before propagating it, e.g.:
		(aFailure name: #anotherName) propagate
	 but the instigator and generator remain unchanged.

	 A failure keeps a stack of its propagators (invocations of propagate).
	 You can print out this stack in a debugger pane with a 'printIt' of:
		aFailure methods
	 to get a collection of (class selector) two-element-arrays, or with a 'printIt' of:
		aFailure receivers
	 to get a collection of the objects running those methods.

	 You can invoke:
		aFailure reply: aReply
	 It will cause the top propagator to be popped from the stack and to
	 return aReply to its caller.  If the stack is empty, it is an error.
	 Thus, a typical call on 'propagate', other than the initial call, is:
		aFailure reply: aFailure propagate
	 and a typical initial call is:
		reply _ (Failure name: #aName) propagate
	 To prevent a failure from receiving a reply, send it 'noReply'.  Example:
		(Failure name: #aName) noReply propagate
	 To find out whether a failure can receive a reply, send it 'canReply'.

	 Note that 'reply:' pops the Context stack, while 'propagate' does not do so.
	 Returning from or falling off the end of a handler also pops the context stack.

	 You can invoke:
		aFailure retry
	 It will re-evaluate the generator of the failure and answer its value; if it
	 fails again, it will behave like a failure generated by the caller of 'retry',
	 and thus will not run the original handler of aFailure.  A typical call is:
		[aFailure reply: aFailure retry] ifFail: [:anotherFailure | moreCode].
	 To prevent a failure from being retried, send it 'noRetry'.  Example:
		answer _ (aFailure name: #newName) noRetry propagate
	 To find out whether a failure can be retried, send it 'canRetry'."


	aOneArgBlock numArgs = 1 ifFalse:
		[self notify: 'ifFail: argument must be a one-argument block'].
	^self value