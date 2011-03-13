scalarXAt: index xArray: xArray headingArray: headingArray value: val destWidth: destWidth leftEdgeMode: leftEdgeMode rightEdgeMode: rightEdgeMode

	| newX headingRadians |
	newX _ val.
	newX < 0.0 ifTrue: [
		leftEdgeMode = 1 ifTrue: [
			"wrap"
			newX _ newX + destWidth.
		].
		leftEdgeMode = 2 ifTrue: [
			"stick"
			newX _ 0.0.
		].
		leftEdgeMode = 3 ifTrue: [
			"bounce"
			newX _ 0.0 - newX.
			headingRadians _ headingArray at: index.
			headingRadians <  3.141592653589793
				ifTrue: [headingArray at: index put: 3.141592653589793 - headingRadians]
				ifFalse: [headingArray at: index put: 9.42477796076938 - headingRadians].
		].
	].

	newX >= destWidth ifTrue: [
		rightEdgeMode = 1 ifTrue: [
			newX _ newX - destWidth.
		].
		rightEdgeMode = 2 ifTrue: [
			newX _ destWidth - 0.000001.
		].
		rightEdgeMode = 3 ifTrue: [
			newX _ (destWidth - 0.000001) - (newX - destWidth).
			headingRadians _ headingArray at: index.
			headingRadians < 3.141592653589793
				ifTrue: [headingArray at: index put: (3.141592653589793 - headingRadians)]
				ifFalse: [headingArray at: index put: (9.42477796076938 - headingRadians)].
		]
	].
	xArray at: index put: newX.
