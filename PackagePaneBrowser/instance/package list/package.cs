package
	"Answer the receiver's 'package'."

	^packageListIndex = 0
		ifFalse: [self packageList at: packageListIndex]
		ifTrue: [nil]