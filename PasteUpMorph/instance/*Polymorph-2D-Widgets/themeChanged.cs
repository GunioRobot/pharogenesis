themeChanged
	"The theme has changed.
	Update the desktop wallpaper if appropriate."

	(self theme desktopFillStyleFor: self) ifNotNilDo: [:fs |
		self fillStyle: fs].
	super themeChanged