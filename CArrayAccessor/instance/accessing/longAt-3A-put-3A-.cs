longAt: index put: value
	^object basicAt: (offset + index) // 4 + 1 put: value