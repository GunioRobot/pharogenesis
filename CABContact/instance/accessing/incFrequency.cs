incFrequency
	frequency
		ifNil: [frequency _ 1.
			^ self].
	frequency _ frequency + 1