decodeMCU

	| comp |
	(restartInterval ~= 0 and: [restartsToGo = 0]) ifTrue: [self processRestart].
	mcuMembership withIndexDo:
		[:ci :i |
		comp _ currentComponents at: ci.
		self
			decodeBlockInto: (mcuSampleBuffer at: i)
			component: comp
			dcTable: (hDCTable at: comp dcTableIndex)
			acTable: (hACTable at: comp acTableIndex)].
	restartsToGo _ restartsToGo - 1.