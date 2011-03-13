offerFontMenu
	"Present a menu of available fonts, and if one is chosen, apply it to the current selection.  5/27/96 sw
	Use only names of Fonts of this paragraph  8/19/96 tk"

	| aList reply |
	aList _ paragraph textStyle fontNames.
	reply _ (SelectionMenu labelList: aList selections: aList) startUp.
	reply ~~ nil ifTrue:
		[self replaceSelectionWith:
			(Text string: self selection asString emphasis: (aList indexOf: reply))] 