generateRotatedForm
	"Compute my rotatedForm and offsetWhenRotated."

	| pair smoothPix formAngle |
	formAngle _ self forwardDirection.  "where user wants forward to be on the picture"
	formAngle ifNil: [formAngle _ 0.0].
	formAngle _ rotationDegrees - formAngle.  "apply correction"
	rotationStyle = #leftRight ifTrue: [
		rotationDegrees >= 0 ifTrue: [
			"headed right; use original"
			rotatedForm _ originalForm.
			offsetWhenRotated _ 0@0.
		] ifFalse: [
			"headed left; use flipped"
			rotatedForm _ originalForm flipBy: #horizontal centerAt: 0@0.
			offsetWhenRotated _ (2 * (rotationCenter x - (originalForm width // 2)))@0.
		].
		^ self].

	rotationStyle = #upDown ifTrue: [
		(rotationDegrees abs <= 90.0) ifTrue: [
			"headed up; use original"
			rotatedForm _ originalForm.
			offsetWhenRotated _ 0@0.
		] ifFalse: [
			"headed down; use flipped"
			rotatedForm _ originalForm flipBy: #vertical centerAt: 0@0.
			offsetWhenRotated _ 0@(2 * (rotationCenter y - (originalForm height // 2))).
		].
		^ self].

	"do the actual rotation!"
	((scalePoint x < 1.0) or: [scalePoint y < 1.0])
		ifTrue: [smoothPix _ 2]
		ifFalse: [smoothPix _ 1].
	pair _ WarpBlt
		rotate: originalForm
		degrees: formAngle negated
		center: rotationCenter
		scaleBy: self scalePoint
		smoothing: smoothPix.
	rotatedForm _ pair first.
	offsetWhenRotated _ pair last.
