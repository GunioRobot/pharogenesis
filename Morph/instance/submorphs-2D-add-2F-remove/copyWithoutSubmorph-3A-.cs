copyWithoutSubmorph: sub
	"Needed to get a morph to draw without one of its submorphs.
	NOTE:  This must be thrown away immediately after use."
	^ self clone privateSubmorphs: (submorphs copyWithout: sub)