directoryNames
	| dirNames projectNames entries |
	"Return a collection of names for the subdirectories of this directory but filter out project directories."

	entries _ self entries.
	dirNames _ (entries select: [:entry | entry at: 4])
		collect: [:entry | entry first].
	projectNames _ Set new.
	entries do: [:entry | 
		((entry at: 4) not
			and: ['*.pr' match: entry first])
			ifTrue: [projectNames add: (entry first copyFrom: 1 to: entry first size-3)]].
	^dirNames reject: [:each | projectNames includes: each]
