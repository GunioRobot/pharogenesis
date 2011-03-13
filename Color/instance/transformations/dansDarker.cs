dansDarker
	"Return a darker shade of the same color.
	An attempt to do better than the current darker method."
	^ Color h: self hue s: self saturation
		v: (self brightness - 0.16 max: 0.0)