computeLineStyleLists
	"Compute the line style index lists.
	Each line style will be splitted into two parts, the width and the fill.
	Then, the fills will be added to the fillStyles and the indexes will be adjusted.
	Finally, we compute two arrays containing the width of each line and the
	fill style of each line"
	| widthList fillList indexMap oldIndex newIndex allFillStyles style |
	allFillStyles := Dictionary new.
	fillStyles associationsDo:[:assoc| 
		allFillStyles at: assoc key put: assoc value].
	indexMap := Dictionary new.
	lineStyles associationsDo:[:assoc|
		oldIndex := assoc key.
		style := assoc value.
		allFillStyles at: allFillStyles size+1 put: (SolidFillStyle color: style color).
		newIndex := allFillStyles size.
		indexMap at: oldIndex put: newIndex.
	].
	widthList := OrderedCollection new: lineStyles size.
	fillList := OrderedCollection new: lineStyles size.
	lineStyleList contents do:[:index|
		index = 0 ifTrue:[
			widthList add: 0.
			fillList add: 0.
		] ifFalse:[
			style := lineStyles at: index ifAbsent:[FlashLineStyle color: Color black width: 20].
			widthList add: style width.
			fillList add: (indexMap at: index ifAbsent:[1]).
		].
	].
	widthList := widthList as: ShortRunArray.
	fillList := fillList as: ShortRunArray.
	^Array with: allFillStyles with: fillList with: widthList