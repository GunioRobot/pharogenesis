dragVertex: evt fromHandle: handle vertIndex: label

	| ext oldR pt strokeOrigin offset |
label == #center ifTrue: [
	offset _ evt cursorPoint - (handles at: 1) bounds center.
	self position: self position + offset.
	].

label == #outside ifTrue: [
	strokeOrigin _ (handles at: 1) bounds center.
	pt _ strokeOrigin - evt cursorPoint - ((handles at: 2) extent // 2).
	ext _ pt r.
	oldR _ ext.
	vertices _ (0 to: 359 by: (360//vertices size)) collect: [:angle |
		(Point r: (oldR _ oldR = ext ifTrue: [ext*5//12] ifFalse: [ext]) degrees: angle + pt degrees)
			+ strokeOrigin].
	(handles at: 2) position: evt cursorPoint.
	].
self computeBounds.
