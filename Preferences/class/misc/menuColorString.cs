menuColorString
	^ (self valueOfFlag: #menuColorFromWorld)
		ifFalse:
			['start menu-color-from-world']
		ifTrue:
			['stop menu-color-from-world']