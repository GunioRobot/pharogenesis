nextOrBranch
	"Return a new automaticVersion that is either
	the next following my version, or if that is taken
	a branch, or if that is taken too - a branch from it and so on.
	Yes, it sucks, but I don't have time hacking VersionNumber right now."

	| nextVersion nextBranch |
	nextVersion := automaticVersion next.
	(package releaseWithAutomaticVersion: nextVersion) ifNil: [^nextVersion].
	nextBranch := automaticVersion branchNext.
	[(package releaseWithAutomaticVersion: nextBranch) notNil]
		whileTrue: [nextBranch := nextBranch branchNext].
	^nextBranch 
