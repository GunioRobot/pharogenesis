selectedInfo
	^ ancestry withAllAncestors at: self selection ifAbsent: [nil]