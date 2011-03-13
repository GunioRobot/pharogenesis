chooseExternalNameFor: anObject
	| avail used |
	avail _ self favoredActorNames asOrderedCollection.
	avail removeAllFoundIn: (used _ playfield world allKnownNames).
	avail size > 0 ifTrue: [^ avail atRandom].

	^ Utilities keyLike: 'obj1' satisfying: [:f |  (used includes: f) not]