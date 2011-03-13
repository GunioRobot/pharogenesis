update: aParameter 
	"Refer to the comment in View|update:."

	highlightForm == nil
		ifTrue: [self interrogateModel 
					ifTrue: [self displayComplemented]
					ifFalse: [self displayNormal]]
		ifFalse: [self display]