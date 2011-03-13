resumeFrom: player
	playDirection ~= 0 ifTrue: [^ self].  "Already running"
	playDirection _ 1.
	pianoRoll ifNil:
		["Sync movie to score player if not a clip player"
		scorePlayer _ player].
	self startRunning