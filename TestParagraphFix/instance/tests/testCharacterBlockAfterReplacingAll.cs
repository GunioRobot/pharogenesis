testCharacterBlockAfterReplacingAll
	para replaceFrom: 1 to: 3 with: 'mmm' displaying: false.
	self assert: (para characterBlockForIndex: 4) stringIndex = 4