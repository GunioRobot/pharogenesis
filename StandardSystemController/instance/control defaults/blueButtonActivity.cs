blueButtonActivity
	ScheduledBlueButtonMenu ifNil: [^ super controlActivity].
	ScheduledBlueButtonMenu invokeOn: self