upgradeIsMerge
	^ self
		valueOfFlag: #upgradeIsMerge
		ifAbsent: [false]