debugDraw
	| entry minY maxY lX lY canvas |
	entry _ BalloonEdgeData new.
	canvas _ Display getCanvas.
	minY _ (start y min: end y) min: via y.
	maxY _ (start y max: end y) max: via y.
	entry yValue: minY.
	self stepToFirstScanLineAt: minY in: entry.
	lX _ entry xValue.
	lY _ entry yValue.
	minY+1 to: maxY do:[:y|
		self stepToNextScanLineAt: y in: entry.
		canvas line: lX@lY to: entry xValue @ y width: 2 color: Color black.
		lX _ entry xValue.
		lY _ y.
	].
