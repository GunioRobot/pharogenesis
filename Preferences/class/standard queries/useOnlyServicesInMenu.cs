useOnlyServicesInMenu
	^ self
		valueOfFlag: #useOnlyServicesInMenu
		ifAbsent: [false]