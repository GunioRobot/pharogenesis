retry: tryBlock asking: troubleString ifGiveUp: abortActionBlock
	"Execute the given block. If it evaluates to true, return true. If it evaluates to false, prompt the user with the given string to see if he wants to try again. If not, evaluate the abortActionBlock and return false."

	| response |
	[tryBlock value] whileFalse: [
		response _ (PopUpMenu labels: 'Retry\Give Up' withCRs)
			startUpWithCaption: troubleString.
		response = 2 ifTrue: [abortActionBlock value. ^ false]].
	^ true
