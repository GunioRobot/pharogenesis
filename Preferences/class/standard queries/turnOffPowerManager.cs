turnOffPowerManager
	^ self
		valueOfFlag: #turnOffPowerManager
		ifAbsent: [false]