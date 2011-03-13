itemMorphFor: anObject
	"Answer a morph for the object with the appropriate icon."

	|item icon|
	item := RectangleMorph new
		changeTableLayout;
		listDirection: #leftToRight;
		cellPositioning: #center;
		cellInset: 2;
		borderWidth: 0;
		color: Color transparent;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		extent: 20@16.
	icon := self getIconSelector ifNotNil: [self model perform: self getIconSelector withEnoughArguments: {anObject}].
	icon ifNotNil: [
		item addMorphBack: (ImageMorph new newForm: icon)].
	item addMorphBack: (StringMorph contents: anObject asStringOrText).
	^item