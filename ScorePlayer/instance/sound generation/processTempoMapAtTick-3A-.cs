processTempoMapAtTick: scoreTick
	"Process tempo changes through the given score tick."

	| map tempoChanged |
	map _ score tempoMap.
	map ifNil: [^ self].
	tempoChanged _ false.
	[(tempoMapIndex <= map size) and:
	 [(map at: tempoMapIndex) time <= scoreTick]] whileTrue: [
		tempoChanged _ true.
		tempoMapIndex _ tempoMapIndex + 1].

	tempoChanged ifTrue: [
		tempo _ (120.0 * (500000.0 / (map at: tempoMapIndex - 1) tempo)) roundTo: 0.01.
		self tempoOrRateChanged].

