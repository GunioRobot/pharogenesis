drawSubmorphsOn: aCanvas

	| r1 fullG r2 actualCanvas newClip where deferredMorphs case |
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
	r1 _ self innerBounds intersect: aCanvas clipRect.
	r1 area = 0 ifTrue: [^self].
	fullG _ (transform localBoundsToGlobal: self firstSubmorph fullBounds) rounded.
	r2 _ r1 intersect: fullG.
	r2 area = 0 ifTrue: [^self].
	newClip _ (r2 expandBy: 1) rounded intersect: self innerBounds rounded.
	deferredMorphs _ #().
	aCanvas 
		transform2By: transform		"#transformBy: for pure WarpBlt"
		clippingTo: newClip
		during: [:myCanvas |
			self scale > 1.0 ifTrue: [
				actualCanvas _ MultiResolutionCanvas new initializeFrom: myCanvas.
				actualCanvas deferredMorphs: (deferredMorphs _ OrderedCollection new).
			] ifFalse: [
				actualCanvas _ myCanvas.
			].
			submorphs reverseDo:[:m | actualCanvas fullDrawMorph: m].
		]
		smoothing: smoothing.

	deferredMorphs do: [ :each |
		where _ each bounds: each fullBounds in: self.
		case _ 2.
		case = 1 ifTrue: [where _ where origin rounded extent: where extent rounded].
		case = 2 ifTrue: [where _ where rounded].
		each drawHighResolutionOn: aCanvas in: where.
	].

