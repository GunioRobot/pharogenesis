dragVertex: label event: evt fromHandle: handle
	| ext oldR pt center |
	label == #center ifTrue:
		[self position: self position + (evt cursorPoint - handle center)].

	label == #outside ifTrue:
		[center _ handles first center.
		pt _ center - evt cursorPoint.
		ext _ pt r.
		oldR _ ext.
		vertices _ (0 to: 359 by: (360//vertices size)) collect:
			[:angle |
			(Point r: (oldR _ oldR = ext ifTrue: [ext*5//12] ifFalse: [ext])
					degrees: angle + pt degrees)
				+ center].
		handle align: handle center with: evt cursorPoint].

	self computeBounds.
