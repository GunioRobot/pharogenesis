programmedMouseUp: anEvent for: aMorph with: aCodeString

	self flag: #bob.		"no longer used, but there may be old morphs out there"
	anEvent hand showTemporaryCursor: nil.
	(self fullBounds containsPoint: anEvent cursorPoint) ifFalse: [^self].
	[
		Compiler
			evaluate: aCodeString
			for: self
			notifying: nil
			logged: false
	]
		on: ProgressTargetRequestNotification
		do: [ :ex | ex resume: self].		"in case a save/load progress display needs a home"
