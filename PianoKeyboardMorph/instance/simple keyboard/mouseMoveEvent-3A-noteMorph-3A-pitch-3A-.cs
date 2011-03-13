mouseMoveEvent: event noteMorph: noteMorph pitch: pitch

	(noteMorph containsPoint: event cursorPoint) ifFalse:
		["If drag out of me, zap focus so other morphs can see drag in."
		event hand releaseMouseFocus: noteMorph]
