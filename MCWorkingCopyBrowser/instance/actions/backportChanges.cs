backportChanges

	workingCopy ifNotNil:
		[workingCopy needsSaving ifTrue: [^ self inform: 'You must save the working copy before backporting.'].
		self pickAncestorVersionInfo ifNotNilDo:
			[:baseVersionInfo |
			workingCopy backportChangesTo: baseVersionInfo]]