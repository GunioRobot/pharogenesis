restoreDefaultFonts
	"Since this is called from menus, we can take the opportunity to prompt for missing font styles."
	"
	Preferences restoreDefaultFonts
	"

	Preferences setDefaultFonts: #(
		(setSystemFontTo: 'Bitmap DejaVu Sans' 9)
		(setCodeFontTo: 'Bitmap DejaVu Sans' 9)
		(setListFontTo: 'Bitmap DejaVu Sans' 9)
		(setMenuFontTo: 'Bitmap DejaVu Sans' 9)
		(setFlapsFontTo: 'Accuny' 15)
		(setEToysFontTo: 'Accuny' 12)
		(setEToysTitleFontTo: 'Accuny' 12)
		(setPaintBoxButtonFontTo: 'Accuny' 12)
		(setWindowTitleFontTo: 'Bitmap DejaVu Sans' 12)
		(setBalloonHelpFontTo: 'Accuny' 10)
		(setButtonFontTo: 'Accuny' 9))