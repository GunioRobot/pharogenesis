saveStandardSystemFontsDuring: aBlock

	| standardDefaultTextFont standardListFont standardEToysFont standardMenuFont 
	windowTitleFont standardBalloonHelpFont standardCodeFont standardButtonFont |

	standardDefaultTextFont _ Preferences standardDefaultTextFont.
	standardListFont _ Preferences standardListFont.
	standardEToysFont _ Preferences standardEToysFont.
	standardMenuFont _ Preferences standardMenuFont.
	windowTitleFont _ Preferences windowTitleFont.
	standardBalloonHelpFont _ Preferences standardBalloonHelpFont.
	standardCodeFont _ Preferences standardCodeFont.
	standardButtonFont _ Preferences standardButtonFont.
	[aBlock value] ensure: [
		Preferences setSystemFontTo: standardDefaultTextFont.
		Preferences setListFontTo: standardListFont.
		Preferences setEToysFontTo: standardEToysFont.
		Preferences setMenuFontTo: standardMenuFont.
		Preferences setWindowTitleFontTo: windowTitleFont.
		Preferences setBalloonHelpFontTo: standardBalloonHelpFont.
		Preferences setCodeFontTo: standardCodeFont.
		Preferences setButtonFontTo: standardButtonFont].
