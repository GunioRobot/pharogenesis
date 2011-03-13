testSwitching

	testSwitch setSwitchState: false.
	self assert: testSwitch isOff.
	self assert: testSwitch color = testSwitch offColor.
	testSwitch setSwitchState: true.
	self assert: testSwitch isOn.
	self assert: testSwitch color = testSwitch onColor.