installAsDefault  "FontSetNewYork installAsDefault"
	(self confirm: 'Do you want to install' translated, '
''' , self fontName , ''' as default font?' translated)
		ifFalse: [^ self].
	self installAsTextStyle.
	"TextConstants at: #OldDefaultTextStyle put: TextStyle default."
	TextConstants at: #DefaultTextStyle put: (TextStyle named: self fontName).
	ListParagraph initialize.
	"rbb 2/18/2005 13:20 - How should this change for UIManger, if at all?"
	PopUpMenu initialize.
	"SelectionMenu notify: 'The old text style has been saved
as ''OldDefaultTextStyle''.'"