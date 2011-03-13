primForwardXArray: xArray yArray: yArray headingArray: headingArray value: v destWidth: destWidth destHeight: destHeight leftEdgeMode: leftEdgeMode rightEdgeMode: rightEdgeMode topEdgeMode: topEdgeMode bottomEdgeMode: bottomEdgeMode

	| dist newX newY |
	<primitive: 'primTurtlesForward' module: 'KedamaPlugin'>
	"^ KedamaPlugin doPrimitive: #primTurtlesForward."

	1 to: xArray size do: [:i |
		v isCollection ifTrue: [
			dist _ (v at: i) asFloat.
		] ifFalse: [
			dist _ v asFloat.
		].
		newX _ (xArray at: i) + (dist * (headingArray at: i) cos).
		newY _ (yArray at: i) - (dist * (headingArray at: i) sin).
		KedamaMorph scalarXAt: i xArray: xArray headingArray: headingArray value: newX destWidth: destWidth leftEdgeMode: leftEdgeMode rightEdgeMode: rightEdgeMode.
		KedamaMorph scalarYAt: i yArray: yArray headingArray: headingArray value: newY destHeight: destHeight topEdgeMode: topEdgeMode bottomEdgeMode: bottomEdgeMode.
	].
