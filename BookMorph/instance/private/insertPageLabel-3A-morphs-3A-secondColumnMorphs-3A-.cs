insertPageLabel: labelString morphs: firstColMorphs secondColumnMorphs: secondColMorphs

	| c |
	self insertPageLabel: labelString morphs: firstColMorphs.

	"use a column to align the given morphs, then add them to the page"
	c _ AlignmentMorph newColumn centering: #center.
	c addAllMorphs: secondColMorphs.
	c position: currentPage position + (100@40).
	currentPage addAllMorphs: secondColMorphs.
