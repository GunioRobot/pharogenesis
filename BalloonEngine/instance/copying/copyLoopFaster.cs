copyLoopFaster
	"This is a copy loop drawing one scan line at a time"
	| edge fill reason |
	edge _ BalloonEdgeData new.
	fill _ BalloonFillData new.
	[self primFinishedProcessing] whileFalse:[
		reason _ self primRenderScanline: edge with: fill.
		"reason ~= 0 means there has been a problem"
		reason = 0 ifFalse:[
			self processStopReason: reason edge: edge fill: fill.
		].
	].
	self primGetTimes: Times.
	self primGetCounts: Counts.
	self primGetBezierStats: BezierStats.