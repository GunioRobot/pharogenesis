transformScreenPointToScenePoint: aPoint atDepthOf: anActor
	"Converts a pixel point to a position in the 3D scene using the actor to scale the position of the point. Uses the actor's distance from the camera to determine the depth in the scene."

	| d  x y m scale frustum vector |

	frustum _ self getFrustum.

	d _ (anActor getPosition: self) at: 3.
	scale _ d / (frustum near).

	x _ ((aPoint x) - (myMorph center x)) / ((myMorph width) / 2) * (frustum right) * scale.
	y _ (((aPoint y) - (myMorph center y)) / ((myMorph height) / 2)) * (frustum bottom) * scale.

	m _ B3DMatrix4x4 identity.
	m translation: (B3DVector3 x: x y: y z: d).
	m _ (self getMatrixFromRoot) composeWith: m.

	vector _ (m translation).

	^ { vector at: 1. vector at: 2. vector at: 3 }.
