primDrawOn: destBits destWidth: destWidth destHeight: destHeight xArray: xArray yArray: yArray colorArray: colorArray visibleArray: visibleArray

	| x y visible bitsIndex |
	<primitive: 'drawTurtlesInArray' module: 'KedamaPlugin'>
	"^ KedamaPlugin doPrimitive: #drawTurtlesInArray."

	1 to: xArray size do: [:i |
		x _ (xArray at: i) asInteger.
		y _ (yArray at: i) asInteger.
		visible _ (visibleArray at: i).
		(visible ~= 0 and: [((x >= 0) and: [y >= 0]) and: [(x < destWidth) and: [y < destHeight]]]) ifTrue: [
			bitsIndex _ ((y * destWidth) + x) + 1.
			destBits at: bitsIndex put: (colorArray at: i).
		]
	].
