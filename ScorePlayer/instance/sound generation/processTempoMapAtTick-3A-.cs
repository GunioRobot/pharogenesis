processTempoMapAtTick: scoreTicks

	| map |
	map _ score tempoMap.
	map ifNil: [^ self].
	[(tempoMapIndex <= map size) and:
	 [(map at: tempoMapIndex) time <= scoreTicks]] whileTrue: [
		tempo _ (120.0 * (500000.0 / (map at: tempoMapIndex) tempo)) roundTo: 0.01.
		self tempoOrRateChanged.
		tempoMapIndex _ tempoMapIndex + 1].
