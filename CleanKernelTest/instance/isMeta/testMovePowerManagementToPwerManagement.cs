testMovePowerManagementToPwerManagement
	self
		assert: (self isSelector: #disablePowerManager definedInClassOrMetaClass: PowerManagement class).
	self
		assert: (self isSelector: #enablePowerManager definedInClassOrMetaClass: PowerManagement class).
	self
		assert: (self isSelector: #disablePowerManager: definedInClassOrMetaClass: PowerManagement class).
	self
		assert: (self isSelector: #itsyVoltage definedInClassOrMetaClass: PowerManagement class)