cleanseDisabledGlobalFlapsList
	"Make certain that the items on the disabled-global-flap list are actually global flaps, and if not, get rid of them"

	| disabledFlaps currentGlobals |
	disabledFlaps _ self parameterAt: #disabledGlobalFlaps ifAbsent: [^ self].
	currentGlobals _ Utilities globalFlapTabsIfAny.
	disabledFlaps _ disabledFlaps select: [:aFlapTab | currentGlobals includes: aFlapTab].
	self projectParameterAt: #disabledGlobalFlaps put: disabledFlaps