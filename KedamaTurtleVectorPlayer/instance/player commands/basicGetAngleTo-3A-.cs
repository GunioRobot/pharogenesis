basicGetAngleTo: players

	| ret p xArray yArray result |
	players isCollection ifFalse: [
		p _ players
	].
	xArray _ arrays at: 2.
	yArray _ arrays at: 3.
	result _ KedamaFloatArray new: self size.
	1 to: self size do: [:index |
		players isCollection ifTrue: [
			p _ players at: index.
		].
		ret _ ((p getX - (xArray at: index))@(p getY - (yArray at: index))) theta radiansToDegrees + 90.0.
		ret > 360.0 ifTrue: [ret _ ret - 360.0].
		result at: index put: ret.
	].
	^ result.
