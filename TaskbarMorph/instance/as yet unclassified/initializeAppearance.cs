initializeAppearance
	"Initialize the appearance."

	self
		color: (Color black alpha: 0.3);
		fillStyle: (self theme taskbarFillStyleFor: self)