drawSimulatedOn: aCanvas
	"Draw the receiver using the builtin software renderer"
	(myRenderer notNil and:[myRenderer isOverlayRenderer]) ifTrue:[
		"Dump it. We may just being dragged around by the hand."
		myRenderer destroy.
		myRenderer _ nil].
	aCanvas asBalloonCanvas render: self.
	outline ifNotNil:[self sketchOn: aCanvas].