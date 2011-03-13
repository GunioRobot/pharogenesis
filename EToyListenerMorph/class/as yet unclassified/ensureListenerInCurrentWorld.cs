ensureListenerInCurrentWorld

	| w |
	w := self currentWorld.
	EToyListenerMorph allInstances 
		detect: [ :each | each world == w]
		ifNone: [EToyListenerMorph new open]