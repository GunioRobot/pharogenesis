stepStillDown: dummy with: theButton
	(stepButton == nil or: [stepButton isInWorld not]) ifTrue: [stepButton _ theButton].
	self stepButtonState: true.
	self stopButtonState: false.
	associatedMorph stepAll.
	associatedMorph world displayWorld.
	self stepButtonState: false.
	self stopButtonState: true
