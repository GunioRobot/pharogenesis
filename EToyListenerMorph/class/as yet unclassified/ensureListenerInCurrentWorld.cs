ensureListenerInCurrentWorld

	| w |
	w _ self currentWorld.
	EToyListenerMorph allInstances 
		detect: [ :each | each world == w]
		ifNone: [EToyListenerMorph new open]