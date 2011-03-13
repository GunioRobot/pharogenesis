clipRect: aRectangle 
	"This method is never run. It is here just so that the sends in it can be
	tallied by the SendInfo interpreter."
	super clipRect: aRectangle.
	(state notNil
			and: [self bitBlt notNil])
		ifTrue: [state bitBlt clipRect: aRectangle]