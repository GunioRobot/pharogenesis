openOn: aScore title: aString

	| player m w |
	player _ ScorePlayer onScore: aScore.
	player play.  "start playing immediately"
	m _ self new onScorePlayer: player title: aString.
	w _ WorldMorph new.
	w addMorph: m.
	MorphWorldView
		openOn: w
		label: aString
		extent: m fullBounds extent + 2.
