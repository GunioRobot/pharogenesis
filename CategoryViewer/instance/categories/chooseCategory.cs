chooseCategory
	"The mouse went down on the receiver; pop up a list of category choices"

	| aList aMenu reply aLinePosition lineList |
	aList _ scriptedPlayer categoriesForViewer: self.
	aLinePosition _ aList indexOf: #miscellaneous ifAbsent: [nil].
	lineList _ aLinePosition ifNil: [#()] ifNotNil: [Array with: aLinePosition].
	aMenu _ CustomMenu labels: aList lines: lineList selections: aList.
	reply _ aMenu startUpWithCaption: 'category'.
	reply ifNil: [^ self].
	self categoryChoice: reply asSymbol
