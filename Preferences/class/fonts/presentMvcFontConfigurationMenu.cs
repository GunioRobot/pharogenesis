presentMvcFontConfigurationMenu
	| aMenu result |
	aMenu _ CustomMenu new.
	aMenu title: 'Standard System Fonts'.
	aMenu add: 'default text font...' action: #chooseSystemFont.
	aMenu add: 'list font...' action: #chooseListFont.
	aMenu add: 'flaps font...' action: #chooseFlapsFont.
	aMenu add: 'menu font...' action: #chooseMenuFont.
	aMenu add: 'window-title font...' action: #chooseWindowTitleFont.
	"aMenu add: 'code font...' action: #chooseCodeFont."
	aMenu addLine.
	aMenu add: 'restore default font choices' action: #restoreDefaultFonts.

	(result _ aMenu startUp) ifNotNil:
		[self perform: result]
