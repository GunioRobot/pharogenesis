retry: tryBlock asking: troubleString ifGiveUp: abortActionBlock
	"Execute the given block. If it evaluates to true, return true. If it evaluates to false, prompt the user with the given string to see if he wants to try again. If not, evaluate the abortActionBlock and return false."

	| response  |
	[tryBlock value] whileFalse: [
		| sema |
		sema _ Semaphore new.
		WorldState addDeferredUIMessage: [
			response _ (PopUpMenu labels: 'Retry\Give Up' withCRs)
				startUpWithCaption: troubleString.
			sema signal.
		].
		sema wait.
		response = 2 ifTrue: [abortActionBlock value. ^ false]].
	^ true
