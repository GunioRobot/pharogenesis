setY: val

	| topEdgeMode bottomEdgeMode |
	y _ val.
	y < 0.0 ifTrue: [
		topEdgeMode _ world topEdgeMode.
		topEdgeMode == #wrap ifTrue: [
			y _ y + world wrapY.
		].
		topEdgeMode == #stick ifTrue: [
			y _ 0.0.
		].
		topEdgeMode == #bounce ifTrue: [
			y _ val negated.
			headingRadians _ Float twoPi - headingRadians.
		].
	].

	y >= world wrapY ifTrue: [
		bottomEdgeMode _ world bottomEdgeMode.
		bottomEdgeMode == #wrap ifTrue: [
			y _ y - world wrapY.
		].
		bottomEdgeMode == #stick ifTrue: [
			y _ world wrapY - 0.0000001.
		].
		bottomEdgeMode == #bounce ifTrue: [
			y _ world wrapY - 0.0000001 - (y - world wrapY).
			headingRadians _ Float twoPi - headingRadians.
		].
	].
