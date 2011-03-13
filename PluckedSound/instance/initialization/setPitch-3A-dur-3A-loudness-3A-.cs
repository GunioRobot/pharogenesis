setPitch: p dur: d loudness: l

	amplitude _ l rounded.
	ring _ SoundBuffer new: (((2.0 * self samplingRate asFloat) / p asFloat) asInteger max: 2).
	ringSize _ ring size.
	initialCount _ (d * self samplingRate asFloat) asInteger.
	self reset.
