doRot: evt with: rotHandle
	"Update the rotation of my target if it is a kind of SketchMorph."
	| degrees |
	(target isKindOf: SketchMorph) ifTrue:
		[degrees _ (evt cursorPoint - target referencePosition) degrees.
		target rotationDegrees: degrees - angleOffset degrees.
		rotHandle position: evt cursorPoint - (rotHandle extent // 2).
		self layoutChanged].
	(target isKindOf: TransformationMorph) ifTrue:
		[target angle: (evt cursorPoint - target center) theta negated + (Float pi*3.0/4.0).
		rotHandle position: evt cursorPoint - (rotHandle extent // 2).
		self layoutChanged].
