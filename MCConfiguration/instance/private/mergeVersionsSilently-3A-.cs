mergeVersionsSilently: aCollection

	^self suppressMergeDialogWhile: [self mergeVersions: aCollection]