assuredTextStyle
	^ textStyle ifNil:
		[textStyle _  ListParagraph standardListStyle]
