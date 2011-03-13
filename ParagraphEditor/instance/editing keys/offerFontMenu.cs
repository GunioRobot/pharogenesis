offerFontMenu
	"Present a menu of available fonts, and if one is chosen, apply it to the current selection.  
	Use only names of Fonts of this paragraph  "

	| aList reply |
	aList := paragraph textStyle fontNamesWithPointSizes.
	reply := UIManager default chooseFrom: aList values: aList.
	reply ~~ nil ifTrue:
		[self replaceSelectionWith:
			(Text string: self selection asString 
				attribute: (TextFontChange fontNumber: (aList indexOf: reply)))] 