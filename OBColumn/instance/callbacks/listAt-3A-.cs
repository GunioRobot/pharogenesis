listAt: index
	^ (children at: index ifAbsent: [^ '']) displayString