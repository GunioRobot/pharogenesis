fullDrawOn: aCanvas
	| myCanvas |
	aCanvas isBalloonCanvas ifTrue:[^super fullDrawOn: aCanvas].
	myCanvas _ aCanvas asBalloonCanvas.
	myCanvas deferred: true.
	super fullDrawOn: myCanvas.
	myCanvas flush.