endEntry
	| c d cb |
	c _ self contents.
	Display extent ~= DisplayScreen actualScreenSize ifTrue:
		["Handle case of user resizing physical window"
		DisplayScreen startUp.
		frame _ frame intersect: Display boundingBox.
		^ self clear; show: c].
	para setWithText: c asText
		style: TextStyle default
		compositionRectangle: ((frame insetBy: 4) withHeight: 9999)
		clippingRectangle: frame
		foreColor: self black backColor: self white.
	d _ para compositionRectangle bottom - frame bottom.
	d > 0 ifTrue:
		["Scroll up to keep all contents visible"
		cb _ para characterBlockAtPoint: para compositionRectangle topLeft
											+ (0@(d+para lineGrid)).
		self on: (c copyFrom: cb stringIndex to: c size).
		readLimit_ position_ collection size.
		^ self endEntry].
	para display