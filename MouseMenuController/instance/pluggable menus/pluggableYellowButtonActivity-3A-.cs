pluggableYellowButtonActivity: shiftKeyState
	"Invoke the model's popup menu."

	| menu |
	(menu _ self getPluggableYellowButtonMenu: shiftKeyState)
		ifNil:
			[sensor waitNoButton]
		ifNotNil:
			[self terminateAndInitializeAround:
				[menu invokeOn: model orSendTo: self]]