showBoundsInHalo
	^ self
		valueOfFlag: #showBoundsInHalo
		ifAbsent: [false
			"keep scanning"]