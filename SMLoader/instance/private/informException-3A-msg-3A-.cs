informException: ex msg: msg 
	"Tell the user that an error has occurred.
	Offer to open debug notifier."

	(self confirm: msg, 'Would you like to open a debugger?')
		ifTrue: [ex pass]