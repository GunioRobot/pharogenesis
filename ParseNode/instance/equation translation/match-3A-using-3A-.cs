match: aTree using: matchDict 
	"Match myself as a pattern against the tree.  Because I can
	contain variables that match complete subtrees, I keep a dictionary
	of such matches that I found so far."
	^(aTree isMemberOf: self class)
		and: [self specificMatch: aTree using: matchDict]