suspend
	"Stop the process that the receiver represents in such a way 
	that it can be restarted at a later time (by sending the receiver the 
	message resume). If the receiver represents the activeProcess, suspend it. 
	Otherwise remove the receiver from the list of waiting processes."

	self isActiveProcess ifTrue: [
		myList _ nil.
		self primitiveSuspend.
	] ifFalse: [
		myList ifNotNil: [
			myList remove: self ifAbsent: [].
			myList _ nil].
	]
