forward: evt direction: button
	"Move the forward direction arrow of this painting.  When the user
says forward:, the object moves in the direction of the arrow.  evt may be
an Event (from the user moving the arrow), or an initial number ofdegrees."

	| center dir ww ff |
	center _ bounds center "+ (rotationButton width - 6 @ 0)".
	evt isNumber ifTrue: [dir _ Point r: 100 degrees: evt - 90.0
"convert to 0 on X axis"]
		ifFalse: [dir _ evt cursorPoint - center].
	ww _ (bounds height min: bounds width)//2 - 7.
	button setVertices: (Array
		with: (center + (Point r: ww degrees: dir degrees))
		with: (center + (Point r: ww-15 degrees: dir degrees))).
	(ff _ self valueOfProperty: #fwdToggle) position:
		(center + (Point r: ww-7 degrees: dir degrees + 6.5)) - (ff
extent // 2).
	self showDirType.
