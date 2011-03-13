justClonedFrom: donorActor
	"Convert all references to actor1 to actor2, who now owns the script"

	| lastAcceptedScript lastScriptEditor |
	self flag: #noteToTed.   "Code to get all the scripts right in the clone needs to be considered here, esp making the right donorActor:ownActor: calls"

	false ifTrue: [lastAcceptedScript ifNotNil:
		[lastAcceptedScript myMorph == self ifFalse: [self error: 'dup should have done it'].
		"All subMorphs including targets and arguments are fixed up by veryDeepCopy"
		lastAcceptedScript donorActor: donorActor ownActor: self.
		lastAcceptedScript bringUpToDate.
			"Note that both of above two lines rewrite tile's line1 with new external name"
			"Fix this?"
		lastAcceptedScript install].

	lastScriptEditor _ lastAcceptedScript.]
	