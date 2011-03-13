resetViewBoxForReal

	| newClip |
	self viewBox ifNil: [^self].
	newClip _ self viewBox intersect: parentWorld viewBox.
	worldState canvas: (
		Display getCanvas
			copyOffset:  0@0
			clipRect: newClip
	)