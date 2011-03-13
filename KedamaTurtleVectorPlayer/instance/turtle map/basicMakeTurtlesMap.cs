basicMakeTurtlesMap

	| x y xArray yArray width height mapIndex whoArray |
	xArray _ arrays at: 2.
	yArray _ arrays at: 3.
	whoArray _ arrays at: 1.
	width _ kedamaWorld dimensions x.
	height _ kedamaWorld dimensions y.
	turtlesMap atAllPut: 0.

	1 to: self size do: [:index |
		x _ (xArray at: index) truncated.
		y _ (yArray at: index) truncated.
		mapIndex _ (width * y) + x + 1.
		(0 < mapIndex and: [mapIndex <= turtlesMap size]) ifTrue: [
			turtlesMap at: mapIndex put: (whoArray at: index).
		].
	].

	turtleMapValid _ true.
