controlInitialize
	"This window is becoming active."

	model canvas ifNil: [  "i.e., only on first entry"
		"In case of, eg, inspect during balloon help..."
		model submorphsDo: [:m |  "delete any existing balloons"
			(m isKindOf: BalloonMorph) ifTrue: [m delete]].

		model hands do: [:h | h initForEvents].
		view displayView].  "initializes the WorldMorph's canvas"
