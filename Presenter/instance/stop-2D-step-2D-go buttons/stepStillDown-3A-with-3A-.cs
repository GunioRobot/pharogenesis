stepStillDown: dummy with: theButton
	self stepButtonState: true.
	self stopButtonState: false.
	theButton world stepAll; displayWorld.
	(Delay forMilliseconds: 200) wait.
	self stepButtonState: false.
	self stopButtonState: true