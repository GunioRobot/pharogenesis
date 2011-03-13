line: evt 
	"Draw a line on the paintingForm using formCanvas aimed at it."
	| rect oldRect ww now diff cor cColor sOrigin priorEvt |
	sOrigin _ self get: #strokeOrigin for: evt.
	rect _ sOrigin rect: (now _ evt cursorPoint).
	evt shiftPressed
		ifTrue: [diff _ evt cursorPoint - sOrigin.
			now _ sOrigin
						+ (Point r: diff r degrees: diff degrees + 22.5 // 45 * 45).
			rect _ sOrigin rect: now].
	ww _ (self getNibFor: evt) width.
	(priorEvt _ self get: #lastEvent for: evt)
		ifNotNil: [oldRect _ sOrigin rect: priorEvt cursorPoint.
			priorEvt shiftPressed
				ifTrue: [diff _ priorEvt cursorPoint - sOrigin.
					cor _ sOrigin
								+ (Point r: diff r degrees: diff degrees + 22.5 // 45 * 45).
					oldRect _ sOrigin rect: cor].
			oldRect _ oldRect expandBy: ww @ ww.
			"Last draw will always stick out, must erase the area"
			self restoreRect: oldRect].
	cColor _ self getColorFor: evt.
	formCanvas
		line: sOrigin
		to: now
		width: ww
		color: cColor.
	self invalidRect: rect