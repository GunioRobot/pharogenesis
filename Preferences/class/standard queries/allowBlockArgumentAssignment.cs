allowBlockArgumentAssignment
	^ self
		valueOfFlag: #allowBlockArgumentAssignment
		ifAbsent: [false]