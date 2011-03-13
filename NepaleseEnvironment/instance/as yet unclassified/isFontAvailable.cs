isFontAvailable
	
	^ (Smalltalk classNamed: #RomePluginCanvas) 
		ifNil: [false ] ifNotNil: [:canvasClass | canvasClass pangoIsAvailable].
