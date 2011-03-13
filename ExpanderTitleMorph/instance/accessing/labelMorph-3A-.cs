labelMorph: anObject
	"Set the value of labelMorph.
	need to wrap to provide clipping!"

	labelMorph ifNotNil: [self removeMorph: labelMorph owner].
	labelMorph := anObject.
	labelMorph ifNotNil: [self addMorph: (
		Morph new
			color: Color transparent;
			changeTableLayout;
			listDirection: #leftToRight;
			listCentering: #center;
			hResizing: #spaceFill;
			vResizing: #shrinkWrap;
			clipSubmorphs: true;
			addMorph: labelMorph)]