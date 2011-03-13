resumeFrom: player
	playDirection ~= 0 ifTrue: [^ self].  "Already running"
	playDirection := 1.
	pianoRoll ifNil:
		["Sync movie to score player if not a clip player"
		scorePlayer := player].
	self startRunning