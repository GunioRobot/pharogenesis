setTexture
	| tex |
	tex _ B3DTexture fromDisplay:(Rectangle originFromUser: 128@128).
	tex wrap: true.
	tex interpolate: false.
	tex envMode: 0.
	texture _ tex.
	self changed