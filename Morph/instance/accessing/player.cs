player
	"answer the receiver's player"
	^ self hasExtension
		ifTrue: [self extension player]