addArrows
	downArrow _ ImageMorph new image: DownPicture.
	upArrow _ ImageMorph new image: UpPicture.
	upArrow position: bounds topLeft + (2@2).
	downArrow align: downArrow bottomLeft
				with: bounds topLeft + (0 @ TileMorph defaultH) + (2@-2).
	self addMorph: downArrow.
	self addMorph: upArrow.