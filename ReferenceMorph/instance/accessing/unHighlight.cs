unHighlight
	| str |
	isHighlighted := false.
	self borderWidth: 0.
	submorphs notEmpty 
		ifTrue: 
			[ str := submorphs first.
			  (str isKindOf: StringMorph) or: 
				[ (str isKindOf: RectangleMorph) 
					ifTrue: [str color: self regularColor]]]