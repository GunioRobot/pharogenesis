step
	"Track the real joystick whose index is realJoystickIndex."
	"Details:
	  a. if realJoystickIndex is nil we're not tracking a joystick
	  b. [-joyMax..joyMax] is nominal range of joystick in both X and Y
	  c. [-threshold..threshold] is considered 0 to compensate for poor joystick centering"

	| threshold joyMax joyPt joyBtn m mCenter r scaledPt  |
	super step.  "Run ticking user-written scripts if any"
	realJoystickIndex ifNil: [^ self].
	threshold _ 30.
	joyMax _ 350.
	joyPt _ Sensor joystickXY: realJoystickIndex.
	joyBtn _ Sensor joystickButtons: realJoystickIndex.

	button1 := (joyBtn bitAnd: 1) > 0.
	button2 := (joyBtn bitAnd: 2) > 0.
	
	joyPt x abs < threshold ifTrue: [joyPt _ 0@joyPt y].
	joyPt y abs < threshold ifTrue: [joyPt _ joyPt x@0].
	lastRealJoystickValue = joyPt ifTrue: [^ self].
	lastRealJoystickValue _ joyPt.
	m _ handleMorph.
	mCenter _ m center.
	r _ m owner innerBounds insetBy:
		((mCenter - m fullBounds origin) corner: (m fullBounds corner - mCenter)).
	scaledPt _ r center + ((r extent * joyPt) / (joyMax * 2)) truncated.
	m position: (scaledPt adhereTo: r) - (m extent // 2).
