decodeMCU

	| comp ci |
	(restartInterval ~= 0 and: [restartsToGo = 0]) ifTrue: [self processRestart].
	1 to: mcuMembership size do:[:i|
		ci _ mcuMembership at: i.
		comp _ currentComponents at: ci.
		self
			primDecodeBlockInto: (mcuSampleBuffer at: i)
			component: comp
			dcTable: (hDCTable at: comp dcTableIndex)
			acTable: (hACTable at: comp acTableIndex)
			stream: stream.
	].
	restartsToGo _ restartsToGo - 1.