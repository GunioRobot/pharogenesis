firstRelease
	"Return the first release."

	^releases isEmpty ifTrue: [nil] ifFalse: [releases first]