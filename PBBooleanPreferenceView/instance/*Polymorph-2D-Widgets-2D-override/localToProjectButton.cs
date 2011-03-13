localToProjectButton
	"Answer a checkbox for the local enablement state."
	
	^UITheme current
		newCheckboxIn: World
		for: self preference
		getSelected: #localToProject
		setSelected: #toggleProjectLocalness
		getEnabled: nil
		label: 'local' translated
		help: nil
		