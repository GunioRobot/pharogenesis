adjustBookControls
	| inner |
	startButton ifNil: [^ self].
	startButton align: startButton topLeft with: (inner := self innerBounds) topLeft + (35@-4).
	progress ifNotNil:
		[progress align: progress topLeft with: (startButton right @ inner top) + (10@0)].
	stopButton align: stopButton topRight with: inner topRight - (16@4)