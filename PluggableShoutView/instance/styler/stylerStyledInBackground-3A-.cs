stylerStyledInBackground: styledCopyOfText

	(displayContents text string = styledCopyOfText string)
		ifTrue: [self stylerStyled: styledCopyOfText]