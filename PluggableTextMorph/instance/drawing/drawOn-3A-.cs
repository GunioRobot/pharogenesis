drawOn: aCanvas 
	"Include a thin red inset border for unaccepted edits, or, if the unaccepted edits are known to conflict with a change made somewhere else to the same method (typically), put a thick red frame"

	super drawOn: aCanvas. 
	self wantsFrameAdornments ifTrue:
		[(model notNil and: [model refusesToAcceptCode])
			ifTrue:  "Put up feedback showing that code cannot be submitted in this state"
				[aCanvas frameRectangle: self innerBounds width: 2 color: Color tan]
			ifFalse:
				[self hasEditingConflicts
					ifTrue:
						[aCanvas frameRectangle: self innerBounds width: 3 color: Color red] 
					ifFalse:
						[self hasUnacceptedEdits
							ifTrue:
								[model wantsDiffFeedback
									ifTrue:
										[aCanvas frameRectangle: self innerBounds width: 3 color: Color green]
									ifFalse:
										[aCanvas frameRectangle: self innerBounds width: 1 color: Color red]]
							ifFalse:
								[model wantsDiffFeedback
									ifTrue:
										[aCanvas frameRectangle: self innerBounds width: 1 color: Color green]]]]]