drawOn: aCanvas
	"Optimization: Do not draw myself if the movie player is one of my submorphs and the only damage is contained within it. This avoids overdrawing while playing a movie."

	((moviePlayer owner == self) and:
	 [moviePlayer bounds containsRect: aCanvas clipRect])
		ifFalse: [super drawOn: aCanvas].
