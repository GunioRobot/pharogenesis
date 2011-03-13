drawOn: aCanvas 
	"Include a thin red inset border for unaccepted edits, or, if the unaccepted edits are known to conflict with a change made somewhere else to the same method (typically), put a thick red frame"

	super drawOn: aCanvas. 
	self wantsFrameAdornments ifTrue:
		[self hasEditingConflicts
			ifTrue:
				[aCanvas frameRectangle: self innerBounds width: 3 color: Color red] 
			ifFalse:
				[self hasUnacceptedEdits
					ifTrue:
						[model showDiffs
							ifTrue:
								[aCanvas frameRectangle: self innerBounds width: 3 color: Color green]
							ifFalse:
								[aCanvas frameRectangle: self innerBounds width: 1 color: Color red]]
					ifFalse:
						[model showDiffs
							ifTrue:
								[aCanvas frameRectangle: self innerBounds width: 1 color: Color green]]]]