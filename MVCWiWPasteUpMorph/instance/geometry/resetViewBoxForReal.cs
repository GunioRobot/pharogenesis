resetViewBoxForReal

	self viewBox ifNil: [^self].
	worldState canvas: (
		(Display getCanvas)
			copyOffset:  0@0
			clipRect: self viewBox
	)