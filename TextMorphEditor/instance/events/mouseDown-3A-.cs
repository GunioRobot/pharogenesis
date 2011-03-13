mouseDown: evt 
	"An attempt to break up the old processRedButton code into threee phases"
	| clickPoint |
	oldInterval _ startBlock stringIndex to: stopBlock stringIndex - 1.
	clickPoint _ evt cursorPoint.
	(paragraph clickAt: clickPoint for: model controller: self) ifTrue: [^ self].
	self closeTypeIn.  "probably not necess"
	sensor leftShiftDown
		ifFalse:
			[stopBlock _ startBlock _ pivotBlock _
				paragraph characterBlockAtPoint: clickPoint]
		ifTrue:
			[(paragraph characterBlockAtPoint: clickPoint) <= startBlock
			ifTrue: [stopBlock _ startBlock.
					pivotBlock _ stopBlock]
			ifFalse: [startBlock _  stopBlock.
					pivotBlock _ startBlock]].
	paragraph selectionStart: startBlock selectionStop: stopBlock