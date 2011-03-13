getAngleTo: players

	| p xArray yArray result pX pY xy |
	players isCollection ifFalse: [
		p _ players
	].
	xArray _ arrays at: 2.
	yArray _ arrays at: 3.
	result _ KedamaFloatArray new: self size.
	players isCollection ifTrue: [
		pX _ KedamaFloatArray new: players size.
		pY _ KedamaFloatArray new: players size.
		1 to: players size do: [:i |
			xy _ (players at: i) getXAndY.
			pX at: i put: xy x.
			pY at: i put: xy y.
		].
	] ifFalse: [
		xy _ p getXAndY.
		pX _ xy x.
		pY _ xy y.
	].
	^ self primGetAngleToX: pX toY: pY xArray: xArray yArray: yArray resultInto: result.

