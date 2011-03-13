makeTurtlesMap

	| xArray yArray width height whoArray ret |
	xArray _ arrays at: 2.
	yArray _ arrays at: 3.
	whoArray _ arrays at: 1.
	width _ kedamaWorld dimensions x.
	height _ kedamaWorld dimensions y.
	turtlesMap ifNil: [turtlesMap _ WordArray new: width * height].

	ret _ self primMakeTurtlesMap: turtlesMap whoArray: whoArray xArray: xArray yArray: yArray width: width height: height.

	ret ifNil: [self basicMakeTurtlesMap].

	turtleMapValid _ true.
