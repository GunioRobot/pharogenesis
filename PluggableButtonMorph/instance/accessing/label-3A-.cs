label: aStringOrTextOrMorph
	"Label this button with the given string or morph."

	| r |
	self removeAllMorphs.
	"nest label in a row for centering"
	r _ AlignmentMorph newRow
		borderWidth: 0;
		layoutInset: 0;
		color: Color transparent;
		hResizing: #shrinkWrap;
		vResizing: #spaceFill;
		wrapCentering: #center; cellPositioning: #leftCenter.
	aStringOrTextOrMorph isMorph
		ifTrue: [
			label _ aStringOrTextOrMorph.
			r addMorph: aStringOrTextOrMorph]
		ifFalse: [
			label _ aStringOrTextOrMorph asString.
			r addMorph: (StringMorph contents: label)].
	self addMorph: r.
