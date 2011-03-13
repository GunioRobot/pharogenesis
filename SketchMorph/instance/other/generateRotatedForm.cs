generateRotatedForm
	"Compute my rotatedForm and offsetWhenRotated."

	| adjustedAngle smoothPix pair |
	adjustedAngle _ rotationDegrees - self forwardDirection.
	((rotationStyle = #leftRight) or:
	 [(rotationStyle = #upDown) or:
	 [rotationStyle = #none]]) ifTrue: [adjustedAngle _ 0.0].

	((adjustedAngle = 0.0) and: [0.0@0.0 = scalePoint])
		ifTrue: [
			rotatedForm _ originalForm.
			offsetWhenRotated _ 0@0]
		ifFalse: [
			"do the actual rotation!"
			((scalePoint x < 1.0) or: [scalePoint y < 1.0])
				ifTrue: [smoothPix _ 2]
				ifFalse: [smoothPix _ 1].
			pair _ WarpBlt
				rotate: originalForm
				degrees: adjustedAngle negated
				center: rotationCenter
				scaleBy: self scalePoint
				smoothing: smoothPix.
			rotatedForm _ pair first.
			offsetWhenRotated _ pair last].

	((rotationStyle = #leftRight) and: [rotationDegrees < 0.0]) ifTrue: [
		"headed left; use flipped"
		rotatedForm _ rotatedForm flipBy: #horizontal centerAt: 0@0.
		offsetWhenRotated _ offsetWhenRotated + (((2 * (rotationCenter x - (originalForm width // 2)))@0) * scalePoint).
		^ self].

	((rotationStyle = #upDown) and: [(rotationDegrees > 90.0) or: [rotationDegrees < -90.0]]) ifTrue: [
		"headed down; use flipped"
		rotatedForm _ rotatedForm flipBy: #vertical centerAt: 0@0.
		offsetWhenRotated _ offsetWhenRotated + ((0@(2 * (rotationCenter y - (originalForm height // 2)))) * scalePoint).
		^ self].
