testState
	self assert: testSwitch isOff.
	self deny: testSwitch isOn.
	testSwitch toggleState.
	self assert: testSwitch isOn.
	self deny: testSwitch isOff