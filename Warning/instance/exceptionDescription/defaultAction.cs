defaultAction
	"The user should be notified of the occurrence of an exceptional occurrence and given an option of continuing or aborting the computation. The description of the occurrence should include any text specified as the argument of the #signal: message."

	Debugger
		openContext: thisContext
		label: 'Warning'
		contents: self messageText, '\\Select Proceed to continue, or close this window to cancel the operation.' withCRs.
	self resume