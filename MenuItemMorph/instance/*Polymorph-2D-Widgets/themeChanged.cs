themeChanged
	"Also pass on to the submenu if any."

	super themeChanged.
	self subMenu ifNotNilDo: [:m | m themeChanged]