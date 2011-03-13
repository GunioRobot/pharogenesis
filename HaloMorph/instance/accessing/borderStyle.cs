borderStyle
	"Answer the border style to use for the receiver.
	Depends on the target and preference."
	
	^(target notNil and: [Preferences showBoundsInHalo and: [target isWorldMorph not]])
		ifTrue: [super borderStyle]
		ifFalse: [SimpleBorder width: 0 color: Color transparent]