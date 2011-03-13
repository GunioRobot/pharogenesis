changeColorTarget: aMorph selector: aSymbol

	| m box points b |
	m _ ColorPickerMorph new
		sourceHand: self;
		target: aMorph;
		selector: aSymbol.
	aMorph
		ifNil: [box _ Rectangle center: self position extent: 50]
		ifNotNil: [box _ aMorph fullBounds].
	points _ #(topCenter rightCenter bottomCenter leftCenter).  "possible anchors"
	1 to: 4 do: [:i |  "Try the four obvious anchor points"
		b _ m bounds
				align: (m bounds perform: (points at: i))
				with: (box perform: (points atWrap: i + 2)).
		(self worldBounds containsRect: b) ifTrue: [  "Yes, it fits"
			m position: b topLeft.
			self world addMorphFront: m.
			m changed.
			^ m]].

	"when all else fails..."
	m position: 20@20.
	self world addMorphFront: m.
	m changed.
	^ m
