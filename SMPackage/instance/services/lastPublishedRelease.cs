lastPublishedRelease
	"Return the latest published release."

	^releases isEmpty ifTrue: [nil] ifFalse: [
		releases reversed detect: [:r | r isPublished] ifNone:[nil]]