resolveConflictsInMerger: aMerger
	| inst |
	inst _ self new merger: aMerger.
	^ inst showModally ifNil: [false]