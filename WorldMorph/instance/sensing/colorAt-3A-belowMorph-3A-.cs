colorAt: aPoint belowMorph: aMorph
	"Return the color of the pixel immediately behind the given morph at the given point."

	| c root |
	c _ FormCanvas extent: 1@1 depth: Display depth.
	c _ c copyOrigin: aPoint negated clipRect: ((0@0) extent: 1@1).
	c fillColor: color.
	root _ aMorph root.
	submorphs reverseDo: [:m |
		m == root ifTrue: [
			(m morphsAt: aPoint) reverseDo: [:subM |
				subM == aMorph ifTrue: [^ c form colorAt: 0@0].
				subM drawOn: c]].
		m fullDrawOn: c].
	hands reverseDo: [:h |
		h submorphsReverseDo: [:m |
			m == root ifTrue: [
				(m morphsAt: aPoint) reverseDo: [:subM |
					subM == aMorph ifTrue: [^ c form colorAt: 0@0].
					subM drawOn: c]].
			m fullDrawOn: c]].
	^ c form colorAt: 0@0
