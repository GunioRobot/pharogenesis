lastPublishedReleaseForCurrentSystemVersionNewerThan: aRelease
	"Return the latest published release marked
	as compatible with the current SystemVersion
	that is newer than the given release."

	^releases isEmpty ifTrue: [nil] ifFalse: [
		releases reversed detect: [:r |
			(r isPublished and: [r newerThan: aRelease])
				and: [r isCompatibleWithCurrentSystemVersion]]
				 	ifNone:[nil]]