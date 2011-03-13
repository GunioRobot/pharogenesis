addLine

	| line |
	line _ RectangleMorph new color: Color black;
		extent: self width@borderWidth;
		position: self left@self lastSubmorph bottom.
	self addMorphBack: line.
