lastRelease
	"Return the latest release."

	^releases isEmpty ifTrue: [nil] ifFalse: [releases last]