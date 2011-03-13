remove
	"Remove the selected class from the system. A Confirmer is created."

	self controlTerminate.
	model removeClass.
	self controlInitialize