remove
	"Remove the selected message from the system. A Confirmer is created."

	self controlTerminate.
	model removeMessage.
	self controlInitialize