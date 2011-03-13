swapMouseButtons
	^ self
		valueOfFlag: #swapMouseButtons
		ifAbsent: [
			OSPlatform current platformFamily ~= #Windows ]