getPointAtMatrix: target
	"create a matrix such that the actor looks at the target using the upDirection"
	| aVector m1 m2 |

	m1 _ B3DMatrix4x4 identity.
	m2 _ B3DMatrix4x4 identity.

	"Calculate the vector to look along"
	(target isKindOf: WonderlandActor)
		ifTrue: [ aVector _ (target getMatrixFromRoot translation) -
								(self getMatrixFromRoot translation) ]
		ifFalse: [ (target isKindOf: Point)
					ifTrue: [
							aVector _ ((myWonderland getDefaultCamera)
								transformScreenPointToScenePoint: target atDepthOf: self).
							aVector _ B3DVector3 x: (aVector at: 1) y: (aVector at: 2)
												z: (aVector at: 3).
							aVector _ aVector - (self getMatrixFromRoot translation).
							]
					ifFalse: [
							aVector _ (B3DVector3 x: (target at: 1) y: (target at: 2)
									z: (target at: 3)) - (self getMatrixFromRoot translation).
							].
				].


	"Calculate the rotation around the z-axis"
	((aVector z) = 0) ifTrue: [ ((aVector x ) > 0) ifTrue: [ m1 rotationAroundY: 90 ]
												ifFalse: [ ((aVector x) = 0) 
													ifTrue: [ m1 rotationAroundY: 0 ]
													ifFalse: [ m1 rotationAroundY: -90 ] ]
							]
					ifFalse: [ ((aVector z) > 0)
									ifTrue: [ m1 rotationAroundY:
										(((aVector x) / (aVector z)) arcTan radiansToDegrees) ]
									ifFalse: [ m1 rotationAroundY: (180 +
										(((aVector x) / (aVector z)) arcTan radiansToDegrees)) ]
							].

	((aVector length) = 0) ifFalse: [
		m2 rotationAroundX: (((aVector y) / (aVector length)) arcSin radiansToDegrees negated) ].

	^ (myParent getMatrixToRoot) composeWith: (m1 composeWith: m2).
