enableDisableGlobalFlap: aFlapTab
	"Toggle the enable/disable status of the given global flap"

	| disabledFlaps |
	disabledFlaps _ self parameterAt: #disabledGlobalFlaps ifAbsent: [self projectParameterAt: #disabledGlobalFlaps put: Set new].
	aFlapTab hideFlap.  "in case open"
	(disabledFlaps includes: aFlapTab)
		ifTrue:
			[disabledFlaps remove: aFlapTab.
			self currentWorld addGlobalFlaps]
		ifFalse:
			[disabledFlaps add: aFlapTab.
			aFlapTab delete].
	self cleanseDisabledGlobalFlapsList

	