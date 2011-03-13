wipeImage: otherImage at: topLeft delta: delta
	"Display wipeImage: (Form fromDisplay: (40@40 extent: 300@300)) reverse
		at: 40@40 delta: 0@-2"
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
	^ self wipeImage: otherImage at: topLeft rectForIndex:
		[:i | i <= nSteps
			ifTrue: [wipeRect translateBy: (i-1)*delta]
			ifFalse: [nil]]