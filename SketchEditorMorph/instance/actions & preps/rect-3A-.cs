rect: evt 
	"While moving corner, just write on the canvas. When done, write on the paintingForm"

	| rect oldRect now diff cor cColor sOrigin priorEvt |
	sOrigin _ self get: #strokeOrigin for: evt.
	rect _ sOrigin rect: (now _ evt cursorPoint).
	cColor _ self getColorFor: evt.
	evt shiftPressed
		ifTrue: [diff _ evt cursorPoint - sOrigin.
			now _ sOrigin
						+ (Point r: (diff x abs min: diff y abs)
									* 2 degrees: diff degrees // 90 * 90 + 45).
			rect _ sOrigin rect: now].
	(priorEvt _ self get: #lastEvent for: evt) isNil
		ifFalse: [oldRect _ sOrigin rect: priorEvt cursorPoint.
			priorEvt shiftPressed
				ifTrue: [diff _ priorEvt cursorPoint - sOrigin.
					cor _ sOrigin
								+ (Point r: (diff x abs min: diff y abs)
											* 2 degrees: diff degrees // 90 * 90 + 45).
					oldRect _ sOrigin rect: cor].
		self restoreRect: oldRect].  		"Last draw will stick out, must erase the area"

	cColor == Color transparent
		ifTrue: [formCanvas
				frameAndFillRectangle: rect
				fillColor: Color transparent
				borderWidth: (self getNibFor: evt) width
				borderColor: Color black]
		ifFalse: [formCanvas
				frameAndFillRectangle: rect
				fillColor: Color transparent
				borderWidth: (self getNibFor: evt) width
				borderColor: cColor].
	self invalidRect: rect