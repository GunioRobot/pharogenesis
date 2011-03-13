initializeOnceOnly 
	"Refer to the comment in Class|initialize.  This is the initilaize message for Object class, but
	if called initialize, then all classes would inherit it as a class message, and clearly this is not
	the default desired."

	self initializeDependentsFields.  "Note this will disconnect views!"
	self initializeErrorRecursion.
	self initializeConfirmMenu.

	"Object initializeOnceOnly"