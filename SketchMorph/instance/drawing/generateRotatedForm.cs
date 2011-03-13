generateRotatedForm
	"Compute my rotatedForm and offsetWhenRotated."
	| scalePt smoothPix pair |
	scalePoint ifNil:[scalePoint _ 1@1].
	scalePt _ scalePoint x abs @ scalePoint y abs.
	rotationStyle == #none ifTrue:[scalePt _ 1@1].
	((scalePt x < 1.0) or: [scalePt y < 1.0])
		ifTrue: [smoothPix _ 2]
		ifFalse: [smoothPix _ 1].
	rotationStyle = #leftRight ifTrue:[
		self heading asSmallAngleDegrees < 0.0 
			ifTrue:[scalePt _ scalePt x negated @ scalePt y]].
	rotationStyle = #upDown ifTrue:[
		self heading asSmallAngleDegrees abs > 90.0
			ifTrue:[scalePt _ scalePt x @ scalePt y negated]].
	scalePt = (1@1) ifTrue:[
		rotatedForm _ originalForm.
	] ifFalse:[
		pair _ WarpBlt current
			rotate: originalForm
			degrees: 0
			center: originalForm boundingBox center
			scaleBy: scalePt
			smoothing: smoothPix.
		rotatedForm _ pair first.
	].