eventHandler
	"answer the receiver's eventHandler"
	^ self hasExtension
		ifTrue: [self extension eventHandler] 