line: evt
	"Draw a line on the paintingForm using formCanvas aimed at it."

	| rect oldRect ww now diff cor |
	rect _ strokeOrigin rect: (now _ evt cursorPoint).
	evt shiftPressed ifTrue:
		[diff _ evt cursorPoint - strokeOrigin.
		now _ strokeOrigin + (Point r: diff r degrees: (diff
degrees + 22.5 // 45 * 45)).
		rect _ strokeOrigin rect: now].
	ww _ palette getNib width.
	lastEvent ifNotNil:
		[oldRect _ strokeOrigin rect: lastEvent cursorPoint.
		lastEvent shiftPressed ifTrue:
			[diff _ lastEvent cursorPoint - strokeOrigin.
			cor _ strokeOrigin + (Point r: diff r degrees:
(diff degrees + 22.5 // 45 * 45)).
			oldRect _ strokeOrigin rect: cor].
		oldRect _ oldRect expandBy: ww@ww.
		"Last draw will always stick out, must erase the area"
		self restoreRect: oldRect].
	formCanvas line: strokeOrigin to: now width: ww color: currentColor.
	self invalidRect: rect.