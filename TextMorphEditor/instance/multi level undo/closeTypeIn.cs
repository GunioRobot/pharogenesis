closeTypeIn

	| begin stop rInterval nInterval newText |

	(UndoMessage sends: #noUndoer) ifFalse:[^super closeTypeIn].
	Preferences multipleTextUndo ifTrue: 
		[
		beginTypeInBlock == nil ifFalse:
			[
				begin _ self startOfTyping.
				stop _ self stopIndex.
				rInterval _ (begin "+ UndoMessage argument" 
																to: begin + UndoSelection size - 1).
				nInterval _ begin to: stop - 1.
				(nInterval = rInterval) ifTrue:[ ^super closeTypeIn ].
				newText _ nInterval size > 0
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
