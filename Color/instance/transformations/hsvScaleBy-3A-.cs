hsvScaleBy: anArray
	"Scale hue, saturation, and brightness by this factor.  Useful for varying brightness under program control.  6/24/96 tk"

	^ Color
		hue: (self hue * (anArray at: 1))	"it does mod 360"
		saturation: ((self saturation * (anArray at: 2)) min: 1.0 max: 0.0)
		brightness: ((self brightness * (anArray at: 3)) min: 1.0 max: 0.0).
