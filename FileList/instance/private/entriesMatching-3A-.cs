entriesMatching: patternString
	"Answer a list of directory entries which match the patternString.
	The patternString may consist of multiple patterns separated by ';'.
	Each pattern can include a '*' or '#' as wildcards - see String>>match:"

	| entries patterns |
	entries _ directory entries.
	patterns _ patternString findTokens: ';'.
	(patterns anySatisfy: [:each | each = '*'])
		ifTrue: [^ entries].
	^ entries select: [:entry | 
		entry isDirectory or: [patterns anySatisfy: [:each | each match: entry first]]]