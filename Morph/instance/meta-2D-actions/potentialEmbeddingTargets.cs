potentialEmbeddingTargets
	"Return the potential targets for embedding the receiver"
	owner ifNil:[^#()].
	^owner morphsAt: self referencePosition behind: self unlocked: true