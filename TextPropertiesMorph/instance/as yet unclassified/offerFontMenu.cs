offerFontMenu
	"Present a menu of available fonts, and if one is chosen, apply it to the current selection.  
	Use only names of Fonts of this paragraph  "

	| aList reply |

	aList _ self activeTextMorph textStyle fontNamesWithPointSizes.
	reply _ (SelectionMenu labelList: aList selections: aList) startUp.
	reply ifNil: [^self].
	self applyToWholeText ifTrue: [self activeEditor selectAll].
	self activeEditor replaceSelectionWith:
		(Text string: self activeEditor selection asString 
			attribute: (TextFontChange fontNumber: (aList indexOf: reply))).
	self activeTextMorph updateFromParagraph.