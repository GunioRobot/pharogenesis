doRot: evt with: rotHandle
	"Update the rotation of my target if it is rotatable."

	| degrees |
	degrees _ (evt cursorPoint - target referencePosition) degrees.
	degrees _ degrees - angleOffset degrees.
	(degrees abs < 1.0) ifTrue: [degrees _ 0.0].
	degrees = 0.0
		ifTrue: [rotHandle color: Color lightBlue]
		ifFalse: [rotHandle color: Color blue].
	target rotationDegrees: degrees.
	rotHandle position: evt cursorPoint - (rotHandle extent // 2).
	self layoutChanged.
