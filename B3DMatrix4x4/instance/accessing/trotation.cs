trotation
	"Return the angular rotation around each axis of the matrix"

	| cp sp cy sy cr sr vAngles |

	vAngles _ B3DVector3 new.

	((self a13) = 0) ifTrue: [ ((self a33) >= 0)  ifTrue: [ vAngles at: 2 put: 0.
													  cr _ (self a11).
													  sr _ (self a12).
													  cp _ (self a33). ]
											 ifFalse: [ vAngles at: 2 put: (Float pi).
														cr _ (self a11) negated.
														sr _ (self a12) negated.
														cp _ (self a33) negated. ]
							]
					ifFalse: [
								vAngles at: 2 put: (((self a13) negated) arcTan: (self a33)).
								cy _ (vAngles at: 3) cos.
								sy _ (vAngles at: 3) sin.
								cr _ (cy * (self a11)) + (sy * (self a31)).
								sr _ (cy* (self a12)) + (sy * (self a32)).
								cp _ (cy * (self a33)) - (sy * (self a13)).
							].

	sp _ (self a23).
 
	vAngles at: 1 put: (sp arcTan: cp).
	vAngles at: 3 put: (sr arcTan: cr).

	vAngles at: 1 put: ((vAngles at: 1) radiansToDegrees).
	vAngles at: 2 put: ((vAngles at: 2) radiansToDegrees).
	vAngles at: 3 put: ((vAngles at: 3) radiansToDegrees).

	^ vAngles.
