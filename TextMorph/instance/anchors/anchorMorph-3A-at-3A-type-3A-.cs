anchorMorph: aMorph at: aPoint type: anchorType
	| relPt index newText block |
	aMorph owner == self ifTrue:[self removeMorph: aMorph].
	aMorph textAnchorType: nil.
	aMorph relativeTextAnchorPosition: nil.
	self addMorphFront: aMorph.
	aMorph textAnchorType: anchorType.
	aMorph relativeTextAnchorPosition: nil.
	anchorType == #document ifTrue:[^self].
	relPt _ self transformFromWorld globalPointToLocal: aPoint.
	index _ (self paragraph characterBlockAtPoint: relPt) stringIndex.
	newText _ Text string: (String value: 1) attribute: (TextAnchor new anchoredMorph: aMorph).
	anchorType == #inline ifTrue:[
		self paragraph replaceFrom: index to: index-1 with: newText displaying: false.
	] ifFalse:[
		index _ index min: paragraph text size.
		index _ paragraph text string lastIndexOf: Character cr startingAt: index ifAbsent:[0].
		block _ paragraph characterBlockForIndex: index+1.
		aMorph relativeTextAnchorPosition: (relPt x - bounds left) @ (relPt y - block top ).
		self paragraph replaceFrom: index+1 to: index with: newText displaying: false.
	].
	self fit.