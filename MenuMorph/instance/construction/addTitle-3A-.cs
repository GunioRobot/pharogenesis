addTitle: aString
	"Add a title line at the top of this menu."

	| title |
	title _ LayoutMorph new setColor: (Color r: 0.5 g: 1 b: 0.75) borderWidth: 1 borderColor: #inset.
	title vResizing: #shrinkWrap.
	title orientation: #vertical.
	title centering: #center.
	title addMorph: (StringMorph new contents: aString).
	self addMorphFront: title.
