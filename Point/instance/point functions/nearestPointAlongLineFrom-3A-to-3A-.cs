nearestPointAlongLineFrom: p1 to: p2
	"Note this will give points beyond the endpoints!"
	"There may be a simpler way; I just followed algebra - Dan I."
	| x1 y1 x2 y2 x21 y21 xx yy y4 x4 |
	p1 x = p2 x ifTrue: [^ p1 x @ y].  "vertical line"
	p1 y = p2 y ifTrue: [^ x @ p1 y].  "horizontal line"
	x1 _ p1 x asFloat.  y1 _ p1 y asFloat.
	x2 _ p2 x asFloat.  y2 _ p2 y asFloat.
	x21 _ x2 - x1.
	y21 _ y2 - y1.
	xx _ x21 * x21.
	yy _ y21 * y21.
	y4 _ ((y2*xx) + (y*yy) - ((x2-x) * y21 * x21))/(xx + yy).
	x4 _ x - ((y4-y) * y21 / x21).
	^ x4 @ y4
"
	| p |
	Pen new place: 0@0; goto: 500@300.
	[Sensor anyButtonPressed] whileFalse:
		[p _ Sensor cursorPoint nearestPointAlongLineFrom: 0@0 to: 500@300.
		2 timesRepeat: [Display reverse: (p extent: 10@10)]]
"
