closeTypeIn

	| begin stop rInterval nInterval newText |

	(UndoMessage sends: #noUndoer) ifFalse:[^super closeTypeIn].
	Preferences multipleTextUndo ifTrue: 
		[
		beginTypeInBlock == nil ifFalse:
			[
				begin := self startOfTyping.
				stop := self stopIndex.
				rInterval := (begin "+ UndoMessage argument" 
																to: begin + UndoSelection size - 1).
				nInterval := begin to: stop - 1.
				(nInterval = rInterval) ifTrue:[ ^super closeTypeIn ].
				newText := nInterval size > 0
										ifTrue: [ paragraph text 
																copyFrom: nInterval first 
																to: nInterval last ]
										ifFalse: [ self nullText ].
				self addEditCommand: 
				 	(EditCommand
							textMorph: morph
							replacedText: UndoSelection copy
							replacedTextInterval: rInterval
							newText: newText 
							newTextInterval: nInterval)
			].
		].
	
	"Call the super regardless, just to keep the standard undo machine happy"
	^super closeTypeIn
