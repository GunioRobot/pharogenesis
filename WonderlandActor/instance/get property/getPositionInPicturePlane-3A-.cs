getPositionInPicturePlane: aCamera
	"Returns the actor's position in the picture plane of the given camera"

	| d x y z pos |

	pos _ self getPosition: aCamera.
	d _ (aCamera getFrustum) near.

	z _ (pos at: 3) abs.

	(z = 0) ifTrue: 	[
						x _ 0.
						y _ 0.
					]
			ifFalse: [
						x _ (d / z) * (pos at: 1).
						y _ (d / z) * (pos at: 2).
					].
					
	^ x @ y.
