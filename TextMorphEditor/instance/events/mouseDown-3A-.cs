mouseDown: evt 
	"An attempt to break up the old processRedButton code into threee phases"
	| clickPoint |

	oldInterval _ self selectionInterval.
	clickPoint _ evt cursorPoint.
	(paragraph clickAt: clickPoint for: model controller: self) ifTrue: [
		pivotBlock _ paragraph characterBlockAtPoint: clickPoint.
		self markBlock: pivotBlock.
		self pointBlock: pivotBlock.
		evt hand releaseKeyboardFocus: self.
		^ self].
	evt shiftPressed
		ifFalse:
			[self closeTypeIn.
			pivotBlock _ paragraph characterBlockAtPoint: clickPoint.
			self markBlock: pivotBlock.
			self pointBlock: pivotBlock.]
		ifTrue:
			[self closeTypeIn.
			self mouseMove: evt].
	self storeSelectionInParagraph