transformScreenVectorToSceneVector: aVector
	"Converts a picture plane vector to a position in the 3D scene."

	| x y d m frustum scale vector |

	frustum _ self getFrustum.

	d _ aVector at: 3.
	scale _ d / (frustum near).

	x _ ((aVector x) - (myMorph center x)) / ((myMorph width) / 2) * (frustum right) * scale.
	y _ (((aVector y) - (myMorph center y)) / ((myMorph height) / 2)) * (frustum bottom) * scale.

	m _ B3DMatrix4x4 identity.
	m translation: (B3DVector3 x: x y: y z: d).
	m _ (self getMatrixFromRoot) composeWith: m.

	vector _ (m translation).

	^ { vector at: 1. vector at: 2. vector at: 3 }.
