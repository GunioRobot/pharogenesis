makeVectorFromDistance: aDistance andDirection: aDirection
	"Generates the vector the object should move along using the specified direction"

	| a3DVector |

	(aDirection = right) ifTrue: [a3DVector _ B3DVector3 x: aDistance y: 0 z: 0]
		ifFalse: [(aDirection = left) ifTrue: [a3DVector _ B3DVector3 x: -1 * aDistance y:0 z:0]
		ifFalse: [(aDirection = up) ifTrue: [a3DVector _ B3DVector3 x: 0 y: aDistance z:0]
		ifFalse: [(aDirection = down) ifTrue: [a3DVector _ B3DVector3 x: 0 y: -1 * aDistance z:0]
		ifFalse: [(aDirection = forward) ifTrue: [a3DVector _ B3DVector3 x: 0 y: 0 z: aDistance]
		ifFalse: [((aDirection = back) or: [aDirection = #backward])
					 ifTrue: [a3DVector _ B3DVector3 x: 0 y: 0 z: -1 * aDistance]
		ifFalse: [ self error: 'Unrecognized direction' ]]]]]].

	^ a3DVector.
