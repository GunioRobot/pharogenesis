peelToFirst
	"Peel the stack back to the second occurance of the currently selected message.  Very useful for an infinite recursion.  Gets back to the second call so you can see one complete recursion cycle, and how it was called at the beginning.  Also frees a lot of space!"

	| upperGuy meth second ctxt |
	contextStackIndex = 0 ifTrue: [^ Beeper beep].
	"self okToChange ifFalse: [^ self]."
	upperGuy _ contextStack at: contextStackIndex.
	meth _ upperGuy method.
	contextStackIndex+1 to: contextStack size do: [:ind |
		(contextStack at: ind) method == meth ifTrue: [
			second _ upperGuy.
			upperGuy _ contextStack at: ind]].
	second ifNil: [second _ upperGuy].
	ctxt _ interruptedProcess popTo: self selectedContext.
	ctxt == self selectedContext
		ifTrue: [self resetContext: second]
		ifFalse: [self resetContext: ctxt].  "unwind error"
