enabledButton
	"Answer a checkbox for the enablement state."
	
	^UITheme current
		newCheckboxIn: World
		for: self preference
		getSelected: #preferenceValue
		setSelected: #preferenceValue:
		getEnabled: nil
		label: 'enabled' translated
		help: nil