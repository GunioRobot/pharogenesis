drawOn: aForm

	| xArray yArray colorArray visibleArray bits x y visible bitsIndex dimX dimY ret |
	xArray _ arrays at: 2.
	yArray _ arrays at: 3.
	colorArray _ arrays at: 5.
	visibleArray _ arrays at: 6.
	bits _ aForm bits.
	dimX _ aForm width.
	dimY _ aForm height.

	ret _ self primDrawOn: bits destWidth: dimX destHeight: dimY xArray: xArray yArray: yArray colorArray: colorArray visibleArray: visibleArray.
	ret ifNotNil: [^ self].

	1 to: self size do: [:index |
		x _ (xArray at: index) truncated.
		y _ (yArray at: index) truncated.
		visible _ (visibleArray at: index) ~= 0.
		(visible and: [((x >= 0) and: [y >= 0]) and: [(x < dimX) and: [y < dimY]]]) ifTrue: [
			bitsIndex _ ((y * dimX) + x) + 1.
			bits at: bitsIndex put: (colorArray at: index).
		].
	].

