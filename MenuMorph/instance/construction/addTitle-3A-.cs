addTitle: aString
	"Add a title line at the top of this menu."

	| title |
	title _ AlignmentMorph new setColor: (Color r: 0.5 g: 1 b: 0.75) borderWidth: 1 borderColor: #inset.
	title vResizing: #shrinkWrap.
	title orientation: #vertical.
	title centering: #center.
	(aString asString findTokens: String cr) do:
		[:line | title addMorphBack: (StringMorph new contents: line)].
	self addMorphFront: title.
