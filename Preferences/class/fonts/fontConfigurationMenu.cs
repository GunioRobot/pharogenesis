fontConfigurationMenu
	| aMenu |
	aMenu _ MenuMorph new defaultTarget: Preferences.
	aMenu addTitle: 'Standard System Fonts'.
	aMenu add: 'default text font...' action: #chooseSystemFont.
	aMenu balloonTextForLastItem: 'Choose the default font to be used for code and  in workspaces, transcripts, etc.'.
	aMenu lastItem font: TextStyle defaultFont.
	aMenu add: 'list font...' action: #chooseListFont.
	aMenu lastItem font: Preferences standardListFont.
	aMenu balloonTextForLastItem: 'Choose the font to be used in list panes'.
	aMenu add: 'flaps font...' action: #chooseFlapsFont.
	aMenu lastItem font: Preferences standardFlapFont.
	aMenu balloonTextForLastItem: 'Choose the font to be used on textual flap tabs'.
	aMenu add: 'menu font...' action: #chooseMenuFont.
	aMenu lastItem font: Preferences standardMenuFont.
	aMenu balloonTextForLastItem: 'Choose the font to be used in menus'.
	aMenu add: 'window-title font...' action: #chooseWindowTitleFont.
	aMenu lastItem font: Preferences windowTitleFont emphasis: 1.
	aMenu balloonTextForLastItem: 'Choose the font to be used in window titles.'.

	aMenu add: 'balloon-help font...' target: BalloonMorph action: #chooseBalloonFont.
	aMenu lastItem font: BalloonMorph balloonFont.
	aMenu balloonTextForLastItem: 'choose the font to be used when presenting balloon help.'.

	"aMenu add: 'code font...' action: #chooseCodeFont.
	aMenu lastItem font: Preferences standardCodeFont.
	aMenu balloonTextForLastItem: 'Choose the font to be used in code panes.'."

	aMenu addLine.
	aMenu add: 'restore default font choices' action: #restoreDefaultFonts.
	aMenu balloonTextForLastItem: 'Use the standard system font defaults'.
	^ aMenu
