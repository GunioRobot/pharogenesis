mouseDown: evt 
	"An attempt to break up the old processRedButton code into threee phases"
	| clickPoint |

	oldInterval := self selectionInterval.
	clickPoint := evt cursorPoint.
	(paragraph clickAt: clickPoint for: model controller: self) ifTrue: [
		pivotBlock := paragraph characterBlockAtPoint: clickPoint.
		self markBlock: pivotBlock.
		self pointBlock: pivotBlock.
		evt hand releaseKeyboardFocus: self.
		^ self].
	evt shiftPressed
		ifFalse:
			[self closeTypeIn.
			pivotBlock := paragraph characterBlockAtPoint: clickPoint.
			self markBlock: pivotBlock.
			self pointBlock: pivotBlock.]
		ifTrue:
			[self closeTypeIn.
			self mouseMove: evt].
	self storeSelectionInParagraph