otherProperties
	"answer the receiver's otherProperties"
	^ self hasExtension
		ifTrue: [self extension otherProperties]