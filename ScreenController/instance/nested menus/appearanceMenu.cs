appearanceMenu 
	"Answer the appearance menu to be put up as a screen submenu"

	^ SelectionMenu labelList:
		#(	'window colors...'
			'system fonts...'
			'full screen on'
			'full screen off'
			'set display depth...'
			'set desktop color...' ) 

		lines: #(2 4)
		selections: #(windowSpecificationPanel configureFonts
fullScreenOn fullScreenOff setDisplayDepth setDesktopColor)
"
ScreenController new appearanceMenu startUp
"