mouseDown: event onItem: aMorph
	submorphs do:[:m|
		m == aMorph ifFalse:[m isSelected: false]].
	aMorph isSelected: true.