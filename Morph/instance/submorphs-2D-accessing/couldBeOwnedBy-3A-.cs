couldBeOwnedBy: aMorph
	"Return true if self has no WorldMorph in its owner chain (it is not installed anywhere) or has aMorph in owner chain.  Returns false if self is definately owned by someone else, not aMorph.  Used for writing a subtree on the disk.  Need to include morphs with nil owner who are held in inst vars.  "

	| nextOwner prev |
	"is aMorph in my owner chain?"
	nextOwner _ self.
	prev _ nil.
	[nextOwner == aMorph ifTrue: [^ true].
		nextOwner == nil] whileFalse: [prev _ nextOwner.
								nextOwner _ nextOwner owner].
	^ prev isWorldMorph not
	"If chain ends with no WorldMorph, not installed and might be held by aMorph"
	"If installed in a world, and aMorph is in NOT on my owner chain, ^ false"


	