viewLocFor: exitedProject 
	"Look for a view of the exitedProject, and return its center"

	| ctlr |
	world isMorph 
		ifTrue: 
			[world submorphsDo: 
					[:v | 
					((v isSystemWindow) and: [v model == exitedProject]) 
						ifTrue: [^v center]]]
		ifFalse: 
			[ctlr := world controllerWhoseModelSatisfies: [:p | p == exitedProject].
			ctlr ifNotNil: [^ctlr view windowBox center]].
	^Sensor cursorPoint	"default result"