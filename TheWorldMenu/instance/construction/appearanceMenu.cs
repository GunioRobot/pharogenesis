appearanceMenu
	"Build the appearance menu for the world."
	| screenCtrl |

	screenCtrl _ ScreenController new.
	^self fillIn: (self menu: 'appearance...') from: {

		{'window colors...' . { Preferences . #windowSpecificationPanel} . 'Lets you specify colors for standard system windows.'}.
		{'system fonts...' . { self . #standardFontDo} . 'Choose the standard fonts to use for code, lists, menus, window titles, etc.'}.
		{'text highlight color...' . { Preferences . #chooseTextHighlightColor} . 'Choose which color should be used for text highlighting in Morphic.'}.
		{'insertion point color...' . { Preferences . #chooseInsertionPointColor} . 'Choose which color to use for the text insertion point in Morphic.'}.
		nil.
		{#menuColorString . { Preferences . #toggleMenuColorPolicy} . 'Governs whether menu colors should be derived from the desktop color.'}.
		{#roundedCornersString . { Preferences . #toggleRoundedCorners} . 'Governs whether morphic windows and menus should have rounded corners.'}.
		nil.
		{'full screen on' . { screenCtrl . #fullScreenOn} . 'puts you in full-screen mode, if not already there.'}.
		{'full screen off' . { screenCtrl . #fullScreenOff} . 'if in full-screen mode, takes you out of it.'}.
		nil.
		{'set display depth...' . {self. #setDisplayDepth} . 'choose how many bits per pixel.'}.
		{'set desktop color...' . {self. #changeBackgroundColor} . 'choose a uniform color to use as desktop background.'}.
		{'set gradient color...' . {self. #setGradientColor} . 'choose second color to use as gradient for desktop background.'}.
		{'use texture background' . { #myWorld . #setStandardTexture} . 'apply a graph-paper-like texture background to the desktop.'}.
		nil.
		{'clear turtle trails from desktop' . { #myWorld . #clearTurtleTrails} . 'remove any pigment laid down on the desktop by objects moving with their pens down.'}.

	}