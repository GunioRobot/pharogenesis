pluggableYellowButtonActivity: shiftKeyState
	"Invoke the model's popup menu."

	| menu selector |
	(menu _ self getPluggableYellowButtonMenu: shiftKeyState)
		ifNil: [sensor waitNoButton]
		ifNotNil:
			[(selector _ menu startUp) ifNil: [^ self].
			self terminateAndInitializeAround: [model perform: selector orSendTo: self]]