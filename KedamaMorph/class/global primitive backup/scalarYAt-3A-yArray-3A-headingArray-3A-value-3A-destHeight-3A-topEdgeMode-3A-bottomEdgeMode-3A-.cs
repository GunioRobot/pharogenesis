scalarYAt: index yArray: yArray headingArray: headingArray value: val destHeight: destHeight topEdgeMode: topEdgeMode bottomEdgeMode: bottomEdgeMode

	| newY |
	newY _ val.
	newY < 0.0 ifTrue: [
		topEdgeMode = 1 ifTrue: [
			"wrap"
			newY _ newY + destHeight.
		].
		topEdgeMode = 2 ifTrue: [
			"stick"
			newY _ 0.0.
		].
		topEdgeMode = 3 ifTrue: [
			"bounce"
			newY _ 0.0 - newY.
			headingArray at: index put: (6.283185307179586 - (headingArray at: index)).
		].
	].

	newY >= destHeight ifTrue: [
		bottomEdgeMode = 1 ifTrue: [
			newY _ newY - destHeight.
		].
		bottomEdgeMode = 2 ifTrue: [
			newY _ destHeight - 0.000001.
		].
		bottomEdgeMode = 3 ifTrue: [
			newY _ (destHeight - 0.000001) - (newY - destHeight).
			headingArray at: index put: (6.283185307179586 - (headingArray at: index)).
		]
	].
	yArray at: index put: newY.
