processRedButton
	"The user pressed a red mouse button, meaning create a new text 
	selection. Highlighting the selection is carried out by the paragraph 
	itself. Double clicking causes a selection of the area between the nearest 
	enclosing delimitors."

	|  selectionBlocks clickPoint oldDelta oldInterval previousMarkBlock previousPointBlock |

	clickPoint _ sensor cursorPoint.
	(view containsPoint: clickPoint) ifFalse: [^ self].
	(paragraph clickAt: clickPoint for: model controller: self) ifTrue: [^ self].
	oldInterval _ self selectionInterval.
	previousMarkBlock _ self markBlock.
	previousPointBlock _ self pointBlock.
	oldDelta _ paragraph scrollDelta.
	sensor leftShiftDown
		ifFalse:
			[self deselect.
			self closeTypeIn.
			selectionBlocks _ paragraph mouseSelect: clickPoint]
		ifTrue:
			[selectionBlocks _ paragraph extendSelectionMark: self markBlock pointBlock: self pointBlock.
			self closeTypeIn].
	selectionShowing _ true.
	self markBlock: (selectionBlocks at: 1).
	self pointBlock: (selectionBlocks at: 2).
	(self hasCaret
		and: [previousMarkBlock = self markBlock and: [previousPointBlock = self pointBlock]])
		ifTrue: [self selectWord].
	oldDelta ~= paragraph scrollDelta "case of autoscroll"
			ifTrue: [self updateMarker].
	self setEmphasisHere.
	(self isDisjointFrom: oldInterval) ifTrue:
		[otherInterval _ oldInterval]