appearanceMenu
	"Build the appearance menu for the world."

	^self fillIn: (self menu: 'Preferences') from: {

		{'Preference Browser...' . { PreferenceBrowser . #open} . 'Opens a PreferenceBrowser which allows you to alter many settings' } .
		{'System fonts...' . { self . #standardFontDo} . 'Choose the standard fonts to use for code, lists, menus, window titles, etc.'}.
		nil.
		{#toggleScreenString . { Display . #toggleFullScreen}.}.
		{#soundEnablingString . { Preferences . #toggleSoundEnabling}. 'turning sound off will completely disable Squeak''s use of sound.'}.
		{'Set display depth...' . {self. #setDisplayDepth} . 'choose how many bits per pixel.'}.
		{'Set desktop color...' . {self. #changeBackgroundColor} . 'choose a uniform color to use as desktop background.'}.
		{'Set gradient color...' . {self. #setGradientColor} . 'choose second color to use as gradient for desktop background.'}.
		{'Set author full name...' . { Author . #requestFullName }. 'supply full name to be used to identify the author of code and other content.'}.
	}