on: aRectangle
	rect _ aRectangle.
	a _ rect width // 2.
	b _ rect height // 2.
	x _ 0.
	y _ b.
	aSquared _ a * a.
	bSquared _ b * b.
	d1 _ bSquared - (aSquared * b) + (0.25 * aSquared).
	d2 _ nil.
	inFirstRegion _ true.