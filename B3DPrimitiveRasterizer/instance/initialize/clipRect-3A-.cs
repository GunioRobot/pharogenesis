clipRect: aRectangle
	super clipRect: aRectangle.
	(state notNil and:[state bitBlt notNil]) ifTrue:[state bitBlt clipRect: aRectangle].