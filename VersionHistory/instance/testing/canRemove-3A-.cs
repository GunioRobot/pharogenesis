canRemove: aVersion

	| hasPriors followers |
	(versions includes: aVersion) ifFalse: [^false].
	hasPriors := (self versionBefore: aVersion) notNil.
	followers := self versionsAfter: aVersion.		

	"Don't allow versions in the middle to be extracted"
	(hasPriors and: [followers size > 0]) ifTrue: [^false].
	
	"Don't allow versions with more than one follower to be extracted"
	(hasPriors not and: [followers size > 1]) ifTrue: [^false].
	^true

