stringBoundsToUse
	"Answer the bounds to use when drawing the item text."
	
	^self isInDockingBar
		ifTrue: [self bounds
					left: self left+ (Preferences tinyDisplay
						ifTrue: [1]
						ifFalse: [4])]
		ifFalse: [self bounds]