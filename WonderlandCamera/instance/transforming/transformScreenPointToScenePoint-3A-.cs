transformScreenPointToScenePoint: aPoint
	"Converts a pixel point to a position in the 3D scene. Uses the near clipping plane distance for the depth in the scene."

	| d  x y m frustum vector |

	frustum _ self getFrustum.

	d _ frustum near.

	x _ ((aPoint x) - (myMorph center x)) / ((myMorph width) / 2) * (frustum right).
	y _ (((aPoint y) - (myMorph center y)) / ((myMorph height) / 2)) * (frustum bottom).

	m _ B3DMatrix4x4 identity.
	m translation: (B3DVector3 x: x y: y z: d).
	m _ (self getMatrixFromRoot) composeWith: m.

	vector _ (m translation).

	^ { vector at: 1. vector at: 2. vector at: 3 }.
