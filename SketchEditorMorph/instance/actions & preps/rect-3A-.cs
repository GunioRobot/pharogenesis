rect: evt
	"While moving corner, just write on the canvas.  When done, write
on the paintingForm"

	| rect within oldRect now diff cor |
	rect _ strokeOrigin rect: (now _ evt cursorPoint).
	evt shiftPressed ifTrue:
		[diff _ evt cursorPoint - strokeOrigin.
		now _ strokeOrigin +
			(Point r: (diff x abs min: diff y abs)*2 degrees:
(diff degrees // 90 * 90 + 45)).
		rect _ strokeOrigin rect: now].
	lastEvent == nil ifFalse:
		[oldRect _ strokeOrigin rect: lastEvent cursorPoint.
		lastEvent shiftPressed ifTrue:
			[diff _ lastEvent cursorPoint - strokeOrigin.
			cor _ strokeOrigin + (Point r: (diff x abs min:
diff y abs)*2
						degrees: (diff degrees //
90 * 90 + 45)).
			oldRect _ strokeOrigin rect: cor].
		within _ (rect containsRect: oldRect).
		within & (currentColor isTransparent not) ifFalse:
			["Last draw will stick out, must erase the area"
			self restoreRect: oldRect]].
	currentColor == Color transparent
	ifFalse:[
	formCanvas frameAndFillRectangle: rect fillColor: currentColor
		borderWidth: 0 borderColor: Color transparent.]
	ifTrue:[
	formCanvas frameAndFillRectangle: rect fillColor: currentColor
		borderWidth: (palette getNib width) borderColor: Color black].
	self invalidRect: rect.