stylerStyledInBackground: styledCopyOfText 
	"It is possible that the text string	has changed since the styling began. Disregard the styles if styledCopyOfText's string differs with the current textMorph contents string"
	
	textMorph contents string = styledCopyOfText string
		ifTrue: [self stylerStyled: styledCopyOfText]
	