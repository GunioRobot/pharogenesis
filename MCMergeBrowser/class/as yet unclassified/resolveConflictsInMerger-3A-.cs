resolveConflictsInMerger: aMerger
	| inst |
	inst := self new merger: aMerger.
	^ inst showModally ifNil: [false]