updateLiteralLabel
	|  desiredW leader myReadout theWordRandom |
	(myReadout _ self labelMorph) ifNil: [^ self].
	theWordRandom _ submorphs detect: [:m | m isMemberOf: StringMorph].
	myReadout contents: literal stringForReadout.

	leader _ (upArrow ifNil: [0] ifNotNil: [UpArrowAllowance]) + 4.
	desiredW _ leader + theWordRandom width + myReadout width + 5.
	suffixArrow ifNotNil: [desiredW _ desiredW + SuffixArrowAllowance].
	self extent: (desiredW max: self minimumWidth) @ self class defaultH.
	myReadout position: (self left + (leader + 0)) @ (bounds top + 2); fullBounds.
	theWordRandom position: myReadout topRight + (5@0).
	suffixArrow ifNotNil: [suffixArrow align: suffixArrow topRight with:
				bounds topRight + (-2 @ (self height // 2)) - (0 @ (suffixArrow height // 2))].
	self bounds: self fullBounds