getActions
	"Return the actions currently affecting this object"

	^ (myWonderland getScheduler) getActionsFor: self.
