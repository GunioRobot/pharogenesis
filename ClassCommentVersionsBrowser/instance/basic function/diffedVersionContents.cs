diffedVersionContents
	"Answer diffed version contents, maybe pretty maybe not"

	| change class earlier later |
	(listIndex = 0
			or: [changeList size < listIndex])
		ifTrue: [^ ''].
	change _ changeList at: listIndex.
	later _ change text.
	class _ self selectedClass.
	(listIndex == changeList size or: [class == nil])
		ifTrue: [^ later].

	earlier _ (changeList at: listIndex + 1) text.

	^ TextDiffBuilder buildDisplayPatchFrom: earlier to: later inClass: class prettyDiffs: self showingPrettyDiffs