goHome
	| box |
	(owner isInMemory and: [owner notNil]) 
		ifTrue: 
			[self visible 
				ifTrue: 
					[box := owner.
					self left < box left ifTrue: [self position: box left @ self position y].
					self right > box right 
						ifTrue: [self position: (box right - self width) @ self position y].
					self top < box top ifTrue: [self position: self position x @ box top].
					self bottom > box bottom 
						ifTrue: [self position: self position x @ (box bottom - self height)]]]