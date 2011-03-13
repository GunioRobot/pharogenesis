newRadioButtonFor: aThemeClass
	"Answer radio button for selecting a theme"

	^UITheme current
		newRadioButtonIn: World
		for: aThemeClass
		getSelected: #isCurrent
		setSelected: #beCurrent
		getEnabled: nil
		label: aThemeClass themeName
		help: ('Use the {1} theme' translated format: {aThemeClass themeName})