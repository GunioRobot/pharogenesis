basicGetDistanceTo: players

	| p xArray yArray result |
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
		result at: index put: ((p getX - (xArray at: index)) squared + (p getY - (yArray at: index)) squared) sqrt.

	].
	^ result.
