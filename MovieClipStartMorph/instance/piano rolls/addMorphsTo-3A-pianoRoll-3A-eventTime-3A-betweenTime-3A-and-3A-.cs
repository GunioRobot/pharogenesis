addMorphsTo: morphList pianoRoll: pianoRoll eventTime: t betweenTime: leftTime and: rightTime 
	"This code handles both the start and end morphs."

	| startX endX h delta |
	self startTime > rightTime 
		ifTrue: [^self	"Start time has not come into view."].
	self endTime < leftTime ifTrue: [^self	"End time has passed out of view."].
	startX := pianoRoll xForTime: self startTime.
	endX := pianoRoll xForTime: self endTime.
	h := self colorMargin.	"Height of highlight bar over thumbnails."
	morphList add: (self align: self bottomLeft
				with: startX @ (pianoRoll bottom - pianoRoll borderWidth - h)).
	morphList 
		add: (endMorph align: endMorph bounds rightCenter with: endX @ self center y).
	morphList add: (self colorMorph 
				bounds: (self topLeft - (0 @ h) corner: endMorph right @ (self bottom + h))).
	(soundTrackMorph isNil and: [moviePlayerMorph scorePlayer isNil]) 
		ifFalse: 
			["Wants a sound track"

			(soundTrackMorph isNil or: [pianoRoll timeScale ~= soundTrackTimeScale]) 
				ifTrue: 
					["Needs a new sound track"

					self buildSoundTrackMorphFor: pianoRoll].
			morphList add: (soundTrackMorph align: soundTrackMorph bottomLeft
						with: colorMorph topLeft).
			self soundTrackOnBottom 
				ifTrue: 
					[soundTrackMorph align: soundTrackMorph bottomLeft with: self bottomLeft.
					delta := 0 @ self soundTrackHeight.
					self position: self position - delta.
					endMorph position: endMorph position - delta.
					colorMorph position: colorMorph position - delta]]