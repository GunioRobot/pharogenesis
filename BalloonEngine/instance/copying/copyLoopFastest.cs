copyLoopFastest
	"This is a copy loop drawing the entire image"
	| edge fill reason |
	edge _ BalloonEdgeData new.
	fill _ BalloonFillData new.
	[self primFinishedProcessing] whileFalse:[
		reason _ self primRenderImage: edge with: fill.
		"reason ~= 0 means there has been a problem"
		reason = 0 ifFalse:[
			self processStopReason: reason edge: edge fill: fill.
		].
	].
	self primGetTimes: Times.
	self primGetCounts: Counts.
	self primGetBezierStats: BezierStats.