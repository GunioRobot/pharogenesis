defaultAction
	"The user should be notified of the occurrence of an exceptional occurrence and given an option of continuing or aborting the computation. The description of the occurrence should include any text specified as the argument of the #signal: message."

	| continue |
	continue := self confirm: 'Warning: ', self messageText, ' Continue?'.
	continue ifTrue: [self resume]