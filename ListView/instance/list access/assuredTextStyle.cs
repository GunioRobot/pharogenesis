assuredTextStyle
	^ textStyle ifNil:
		[textStyle :=  ListParagraph standardListStyle]
