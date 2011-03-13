getUphillIn: aPatch

	| xArray yArray headingArray result patch |
	xArray _ arrays at: 2.
	yArray _ arrays at: 3.
	headingArray _ arrays at: 4.
	result _ KedamaFloatArray new: self size.
	patch _ aPatch costume renderedMorph.
	1 to: self size do: [:index |
		result at: index put: (patch
			uphillForTurtleX: (xArray at: index)
			turtleY: (yArray at: index)
			turtleHeading: (headingArray at: index)).
	].
	^ result.
