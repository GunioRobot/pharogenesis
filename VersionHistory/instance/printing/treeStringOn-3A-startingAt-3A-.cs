treeStringOn: strm startingAt: aVersion

	| tmp |
	tmp := self mainLineStartingAt: aVersion.
	tmp do: [ :ea | ea versionStringOn: strm. strm space; space ].
	strm cr.
	tmp do: 
		[ :ea | 
		(versions includes: ea branchNext)
			ifTrue: [self treeStringOn: strm startingAt: ea branchNext]].