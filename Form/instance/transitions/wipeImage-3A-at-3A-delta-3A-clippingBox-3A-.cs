wipeImage: otherImage at: topLeft delta: delta clippingBox: clipBox

	| wipeRect bb nSteps |
	bb _ otherImage boundingBox.
	wipeRect _ delta x = 0
		ifTrue:
		[delta y = 0 ifTrue: [nSteps _ 1. bb "allow 0@0"] ifFalse: [
		nSteps _ bb height//delta y abs + 1.  "Vertical movement"
		delta y > 0
			ifTrue: [bb topLeft extent: bb width@delta y]
			ifFalse: [bb bottomLeft+delta extent: bb width@delta y negated]]]
		ifFalse:
		[nSteps _ bb width//delta x abs + 1.  "Horizontal movement"
		delta x > 0
			ifTrue: [bb topLeft extent: delta x@bb height]
			ifFalse: [bb topRight+delta extent: delta x negated@bb height]].
	^ self wipeImage: otherImage at: topLeft clippingBox: clipBox rectForIndex:
		[:i | i <= nSteps
			ifTrue: [wipeRect translateBy: (delta* (i-1))]
			ifFalse: [nil]]