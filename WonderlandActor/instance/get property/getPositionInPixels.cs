getPositionInPixels
	"Returns the actor's position in pixels in the Squeak window"

	| camera morph point x y frustum |

	camera _ myWonderland getDefaultCamera.
	morph _ camera getMorph.

	point _ self getPositionInPicturePlane.

	frustum _ camera getFrustum.

	((point x) < 0) ifTrue: [
			x _ (morph center x) - (((point x) / (frustum left)) * ((morph width) / 2))
						]
				ifFalse: [
			x _ (morph center x) + (((point x) / (frustum right)) * ((morph width) / 2))
						].

	((point y) < 0) ifTrue: [
			y _ (morph center y) + (((point y) / (frustum bottom)) * ((morph height) / 2))
						]
				ifFalse: [
			y _ (morph center y) - (((point y) / (frustum top)) * ((morph height) / 2))
						].

	^ (x @ y) rounded.
	