restoreDefaultMenuParameters
	"Preferences restoreDefaultMenuParameters"
	"Restore the four color choices of the original implementors of MorphicMenus"

	Parameters at: #menuColor put: (Color r: 0.8 g: 0.8 b: 0.8).
	Parameters at: #menuBorderColor put: #raised.
	Parameters at: #menuBorderWidth put: 2.

	Parameters at: #menuTitleColor put: (Color r: 0.5 g: 1 b: 0.75).
	Parameters at: #menuTitleBorderColor put: #inset.
	Parameters at: #menuTitleBorderWidth put: 1.

	Parameters at: #menuLineUpperColor put: (Color r: 0.667 g: 0.667 b: 0.667).
	Parameters at: #menuLineLowerColor put: (Color r: 0.833 g: 0.833 b: 0.833).