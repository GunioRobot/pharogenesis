getPositionInPicturePlane
	"Returns the actor's position in the picture plane of the default camera"

	| camera d x y z pos |

	camera _ myWonderland getDefaultCamera.

	pos _ self getPosition: camera.
	d _ (camera getFrustum) near.

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
