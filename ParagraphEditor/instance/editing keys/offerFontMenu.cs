offerFontMenu
	"Present a menu of available fonts, and if one is chosen, apply it to the current selection.  
	Use only names of Fonts of this paragraph  "

	| aList reply |
	aList _ paragraph textStyle fontNamesWithPointSizes.
	reply _ (SelectionMenu labelList: aList selections: aList) startUp.
	reply ~~ nil ifTrue:
		[self replaceSelectionWith:
			(Text string: self selection asString 
				attribute: (TextFontChange fontNumber: (aList indexOf: reply)))] 