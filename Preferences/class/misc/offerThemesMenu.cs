offerThemesMenu
	"Put up a menu offering the user a choice of themes.  Each theme is represented by a method in category #themes in Preferences class.  The comment at the front of each method is used as the balloon help for the theme"

	"Preferences offerThemesMenu"
	| selectors aMenu |
	selectors _ self class allMethodsInCategory: #themes.
	selectors _ selectors select: [:sel | sel numArgs = 0].
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addTitle: 'Choose a theme to install'.
	selectors do:
		[:sel |
			aMenu add: sel target: self selector: #installTheme: argument: sel.
			aMenu balloonTextForLastItem: (self class firstCommentAt: sel)].
	aMenu addLine.
	aMenu add: 'browse themes' target: self action: #browseThemes.
	aMenu balloonTextForLastItem: 'Puts up a tool that will allow you to view and edit the code underlying all of the available themes'.
	aMenu popUpInWorld.
	"(Workspace new contents: 'here is an example of a new window with your new theme installed') openLabel: 'Testing one two three'"