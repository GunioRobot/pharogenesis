setX: val

	| leftEdgeMode rightEdgeMode |
	x _ val.
	x < 0.0 ifTrue: [
		leftEdgeMode _ world leftEdgeMode.
		leftEdgeMode == #wrap ifTrue: [
			x _ x + world wrapX.
		].
		leftEdgeMode == #stick ifTrue: [
			x _ 0.0.
		].
		leftEdgeMode == #bounce ifTrue: [
			x _ val negated.
			headingRadians < Float pi
				ifTrue: [headingRadians _ Float pi - headingRadians]
				ifFalse: [headingRadians _ Float threePi - headingRadians]
		].
	].

	x >= world wrapX ifTrue: [
		rightEdgeMode _ world rightEdgeMode.
		rightEdgeMode == #wrap ifTrue: [
			x _ x - world wrapX.
		].
		rightEdgeMode == #stick ifTrue: [
			x _ world wrapX - 0.0000001.
		].
		rightEdgeMode == #bounce ifTrue: [
			x _ world wrapX - 0.0000001 - (x - world wrapX).
			headingRadians < Float pi
				ifTrue: [headingRadians _ Float pi - headingRadians]
				ifFalse: [headingRadians _ Float threePi - headingRadians]
		].
	].
