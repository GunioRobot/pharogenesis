writeImage: anArray
	| width height nComponents pixels size |
	width := anArray at: 1.
	height := anArray at: 2.
	size := width * height.
	nComponents := anArray at: 3.
	pixels := anArray at: 4.

	self writeInt32: width.
	self space.
	self writeInt32: height.
	self space.
	self writeInt32: nComponents.
	self space.
	1 to: size do:[:i|
		self writeInt32: (pixels at: i).
	].
