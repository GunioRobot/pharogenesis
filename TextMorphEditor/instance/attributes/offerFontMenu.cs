offerFontMenu
	"Present a menu of available fonts, and if one is chosen, apply it to the current selection.  
	Use only names of Fonts of this paragraph  "
	| aList reply curFont menuList |
true ifTrue:[^self changeTextFont].
	self flag: #arNote. "Move this up once we get rid of MVC"
	curFont _ (paragraph text fontAt: self startIndex withStyle: paragraph textStyle) fontNameWithPointSize.
	aList _ paragraph textStyle fontNamesWithPointSizes.
	menuList _ aList collect:[:fntName|
		fntName = curFont ifTrue:['<on>',fntName] ifFalse:['<off>',fntName]].
	reply _ (SelectionMenu labelList: menuList selections: aList) startUp.
	reply ~~ nil ifTrue:
		[self replaceSelectionWith:
			(Text string: self selection asString 
				attribute: (TextFontChange fontNumber: (aList indexOf: reply)))] 