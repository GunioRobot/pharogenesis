drawSubmorphsOn: aCanvas

	(self innerBounds intersects: aCanvas clipRect) ifFalse: [^self].
	useRegularWarpBlt == true ifTrue: [
		^aCanvas 
			transformBy: transform
			clippingTo: ((self innerBounds intersect: aCanvas clipRect) expandBy: 1) rounded
			during: [:myCanvas |
				submorphs reverseDo:[:m | myCanvas fullDrawMorph: m]
			]
			smoothing: smoothing
	].
	aCanvas 
		transform2By: transform		"#transformBy: for pure WarpBlt"
		clippingTo: ((self innerBounds intersect: aCanvas clipRect) expandBy: 1) truncated
		during: [:myCanvas |
			submorphs reverseDo:[:m | myCanvas fullDrawMorph: m]
		]
		smoothing: smoothing
