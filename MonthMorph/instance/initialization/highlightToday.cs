highlightToday

	todayCache _ Date today.
	self allMorphsDo:
		[:m | (m isKindOf: SimpleSwitchMorph) ifTrue:
				[(m arguments isEmpty not and: [m arguments first = todayCache])
					ifTrue: [m borderWidth: 2; borderColor: Color yellow]
					ifFalse: [m borderWidth: 1; setSwitchState: m color = m onColor]]].

