resizeToFitLabel

	|  desiredW leader myLabel suffixAllowance |
	(myLabel _ self labelMorph) ifNil: [^ self].
	leader _ (upArrow ifNil: [0] ifNotNil: [UpArrowAllowance]) + 4.
	desiredW _ leader + (6 max: myLabel width) + 2.
	suffixAllowance _  suffixArrow ifNotNil: [SuffixArrowAllowance] ifNil: [0].
	self extent: ((desiredW + suffixAllowance) max: self minimumWidth) @ self class defaultH.

	myLabel position: (((self right - (suffixAllowance + 3)) - myLabel width) @ (bounds top + 3)); fullBounds.
	suffixArrow ifNotNil: [suffixArrow align: suffixArrow topRight with:
				bounds topRight + (-2 @ (self height // 2)) - (0 @ (suffixArrow height // 2))].
	self changed.
	self layoutChanged.
