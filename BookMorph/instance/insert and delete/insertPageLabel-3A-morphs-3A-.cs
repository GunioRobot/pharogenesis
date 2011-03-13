insertPageLabel: labelString morphs: morphList

	| m c labelAllowance |
	self insertPage.
	labelString ifNotNil:
			[m _ (TextMorph new extent: currentPage width@20; contents: labelString).
		m lock.
		m position: currentPage position + (((currentPage width - m width) // 2) @ 5).
		currentPage addMorph: m.
		labelAllowance _ 40]
		ifNil:
			[labelAllowance _ 0].

	"use a column to align the given morphs, then add them to the page"
	c _ AlignmentMorph newColumn wrapCentering: #center; cellPositioning: #topCenter.
	c addAllMorphs: morphList.
	c position: currentPage position + (0 @ labelAllowance).
	currentPage addAllMorphs: morphList.
	^ currentPage
