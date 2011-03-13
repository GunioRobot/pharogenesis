drawTextAdornmentsFor: aPluggableTextMorph on: aCanvas
	"Indicate edit status for the given morph."
	
	(aPluggableTextMorph model notNil and: [aPluggableTextMorph model refusesToAcceptCode])
			ifTrue:  "Put up feedback showing that code cannot be submitted in this state"
				[self drawTextAdornmentFor: aPluggableTextMorph color: Color tan on: aCanvas]
			ifFalse:
				[aPluggableTextMorph hasEditingConflicts
					ifTrue:
						[self drawTextAdornmentFor: aPluggableTextMorph color: Color red on: aCanvas] 
					ifFalse:
						[aPluggableTextMorph hasUnacceptedEdits
							ifTrue:
								[aPluggableTextMorph model wantsDiffFeedback
									ifTrue:
										[self drawTextAdornmentFor: aPluggableTextMorph color: Color yellow darker on: aCanvas]
									ifFalse:
										[self drawTextAdornmentFor: aPluggableTextMorph color: Color orange on: aCanvas]]
							ifFalse:
								[aPluggableTextMorph model wantsDiffFeedback
									ifTrue:
										[self drawTextAdornmentFor: aPluggableTextMorph color: Color green on: aCanvas]]]]