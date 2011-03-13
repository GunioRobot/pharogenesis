isFlapEnabled:  aFlapTab
	"Answer whether the given flap tab is enabled in this project"

	| disabledFlaps  |
	disabledFlaps _ self parameterAt: #disabledGlobalFlaps ifAbsent: [^ true].
	^ (disabledFlaps includes: aFlapTab) not