restart
	"Proceed from the initial state of the currently selected context. The 
	argument is a controller on a view of the receiver. That view is closed."
	"Closing now depends on a preference #restartAlsoProceeds - hmm 9/7/2001 16:46"

	| ctxt noUnwindError |
	self okToChange ifFalse: [^ self].
	self checkContextSelection.
	ctxt _ interruptedProcess popTo: self selectedContext.
	noUnwindError _ false.
	ctxt == self selectedContext ifTrue: [
		noUnwindError _ true.
		interruptedProcess restartTop; stepToSendOrReturn].
	self resetContext: ctxt.
	(Preferences restartAlsoProceeds and: [noUnwindError]) ifTrue: [self proceed].
