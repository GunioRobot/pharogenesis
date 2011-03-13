openAsMorphLabel: aString 
	^ (self buildWith: ToolBuilder default labeled: aString)
		openInWorld;
		yourself