advanceToNextProject
	| nextProj |
	(nextProj _ CurrentProject nextProject) ifNotNil:
		 [nextProj enter: true revert: false saveForRevert: false]
