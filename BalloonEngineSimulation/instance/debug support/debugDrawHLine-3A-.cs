debugDrawHLine: yValue
	| canvas |
	canvas _ Display getCanvas.
	canvas
		line: 0 @ (yValue // self aaLevelGet)
		to: Display extent x @ (yValue // self aaLevelGet)
		width: 2
		color: Color green.