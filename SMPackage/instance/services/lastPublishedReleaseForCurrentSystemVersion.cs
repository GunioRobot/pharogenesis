lastPublishedReleaseForCurrentSystemVersion
	"Return the latest published release marked
	as compatible with the current SystemVersion."

	^releases isEmpty ifTrue: [nil] ifFalse: [
		releases reversed detect: [:r |
			r isPublished and: [r isCompatibleWithCurrentSystemVersion]]
				ifNone:[nil]]