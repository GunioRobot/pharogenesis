contents
	"Answer the source code or documentation for the selected method"

	^ self showingDocumentation
		ifFalse:
			[super contents]
		ifTrue:
			[self commentContents]