browseLocalSendersOfMessages
	"Present a menu of the currently selected message, as well as all
	messages sent by it.  Open a message set browser of all implementors
	of the message chosen in or below the selected class"

	self getSelectorAndSendQuery: #browseAllCallsOn:localTo:
		to: self systemNavigation
		with: { self selectedClass }