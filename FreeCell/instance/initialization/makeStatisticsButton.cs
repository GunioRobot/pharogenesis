makeStatisticsButton
	^ self
		buildButton: SimpleButtonMorph new
		target: self
		label: 'Statistics' translated
		selector: #statistics