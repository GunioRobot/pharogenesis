extent: newExtent
	super image: (Form extent: newExtent depth: Display depth).
	lastX _ -1.
	columnForm _ Form extent: (32//image depth)@(image height) depth: image depth.
	pixValMap _ ((1 to: 256) collect:
			[:i | (Color gray: (256-i)/255.0) pixelValueForDepth: columnForm depth])
		as: Bitmap.
