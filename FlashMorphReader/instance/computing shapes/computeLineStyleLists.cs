computeLineStyleLists
	"Compute the line style index lists.
	Each line style will be splitted into two parts, the width and the fill.
	Then, the fills will be added to the fillStyles and the indexes will be adjusted.
	Finally, we compute two arrays containing the width of each line and the
	fill style of each line"
	| widthList fillList indexMap oldIndex newIndex allFillStyles style |
	allFillStyles _ Dictionary new.
	fillStyles associationsDo:[:assoc| 
		allFillStyles at: assoc key put: assoc value].
	indexMap _ Dictionary new.
	lineStyles associationsDo:[:assoc|
		oldIndex _ assoc key.
		style _ assoc value.
		allFillStyles at: allFillStyles size+1 put: (SolidFillStyle color: style color).
		newIndex _ allFillStyles size.
		indexMap at: oldIndex put: newIndex.
	].
	widthList _ OrderedCollection new: lineStyles size.
	fillList _ OrderedCollection new: lineStyles size.
	lineStyleList contents do:[:index|
		index = 0 ifTrue:[
			widthList add: 0.
			fillList add: 0.
		] ifFalse:[
			style _ lineStyles at: index ifAbsent:[FlashLineStyle color: Color black width: 20].
			widthList add: style width.
			fillList add: (indexMap at: index ifAbsent:[1]).
		].
	].
	widthList _ widthList as: ShortRunArray.
	fillList _ fillList as: ShortRunArray.
	^Array with: allFillStyles with: fillList with: widthList