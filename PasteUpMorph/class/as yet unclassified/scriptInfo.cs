scriptInfo
	"Answer a list of arrays which characterize new etoy script commands understood by this kind of morph -- in addition to those already defined by superclasses.  This is used only for initializing an effectively global structure."

	^ #((command clearTurtleTrails)
		(command deleteCard)
		(command goToNextCard)
		(command goToPreviousCard)
		(command initiatePainting)
		(command liftAllPens)
		(command lowerAllPens)
		(command newCard)
		(command roundUpStrays)
		(command unhideHiddenObjects))
