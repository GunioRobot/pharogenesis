processRedButton
	"The user pressed a red mouse button, meaning create a new text 
	selection. Highlighting the selection is carried out by the paragraph 
	itself. Double clicking causes a selection of the area between the nearest 
	enclosing delimitors."

	| previousStartBlock previousStopBlock selectionBlocks tempBlock clickPoint oldDelta oldInterval |

	clickPoint _ sensor cursorPoint.
	(view containsPoint: clickPoint) ifFalse: [^ self].
	oldInterval _ startBlock stringIndex to: stopBlock stringIndex - 1.
	previousStartBlock _ startBlock.
	previousStopBlock _ stopBlock.
	oldDelta _ paragraph scrollDelta.
	sensor leftShiftDown
		ifFalse:
			[self deselect.
			self closeTypeIn.
			selectionBlocks _ paragraph mouseSelect: clickPoint]
		ifTrue:
			[selectionBlocks _ paragraph extendSelectionAt: startBlock endBlock: stopBlock.
			self closeTypeIn].
	selectionShowing _ true.
	startBlock _ selectionBlocks at: 1.
	stopBlock _ selectionBlocks at: 2.
	startBlock > stopBlock
		ifTrue: 
			[tempBlock _ startBlock.
			startBlock _ stopBlock.
			stopBlock _ tempBlock].
	(startBlock = stopBlock 
		and: [previousStartBlock = startBlock and: [previousStopBlock = stopBlock]])
		ifTrue: [self selectWord].
	oldDelta ~= paragraph scrollDelta "case of autoscroll"
			ifTrue: [self updateMarker].
	self setEmphasisHere.
	(self isDisjointFrom: oldInterval) ifTrue:
		[otherInterval _ oldInterval]