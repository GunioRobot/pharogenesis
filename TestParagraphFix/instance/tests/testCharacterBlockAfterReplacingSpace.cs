testCharacterBlockAfterReplacingSpace
	para replaceFrom: 3 to: 3 with: ' ' displaying: false.
	self assert: (para characterBlockForIndex: 4) stringIndex = 4