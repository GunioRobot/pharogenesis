acceptGraphPoint: p at: index
	| ms val points whichLim linePoint other boundedP |
	boundedP _ p adhereTo: graphArea bounds.
	ms _ self msFromX: boundedP x.
	points _ envelope points.
	ms _ self constrain: ms adjacentTo: index in: points.
	(index = 1 or: [(whichLim _ limits indexOf: index) > 0]) ifTrue:
		["Limit points must not move laterally"
		ms _ (points at: index) x].
	val _ self valueFromY: boundedP y.
	points at: index put: ms@val.
	linePoint _ (self xFromMs: ms) @ (self yFromValue: val).
	(whichLim notNil and: [whichLim between: 1 and: 2]) ifTrue:
		["Loop start and loop end must be tied together"
		other _ limits at: (3 - whichLim).  " 1 <--> 2 "
		points at: other put: (points at: other) x @ val.
		line verticesAt: other put: (line vertices at: other) x @ linePoint y].
	"Make sure envelope feels the change in points array..."
	envelope setPoints: points loopStart: (limits at: 1) loopEnd: (limits at: 2).
	^ linePoint