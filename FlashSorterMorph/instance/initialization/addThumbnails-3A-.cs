addThumbnails: extentPoint
	| m morphList handler |
	handler := nil.
	'Preparing thumbnails' displayProgressAt: Sensor cursorPoint
		from: 1 to: player maxFrames during:[:bar|
			morphList := Array new: player maxFrames.
			1 to: player maxFrames do:[:i|
				bar value: i.
				m := FlashThumbnailMorph new.
				m extent: extentPoint.
				m player: player.
				m frameNumber: i.
				handler isNil ifTrue:[
					m on: #mouseDown send: #mouseDown:onItem: to: self.
					m on: #mouseStillDown send: #mouseStillDown:onItem: to: self.
					m on: #mouseUp send: #mouseUp:onItem: to: self.
					handler := m eventHandler.
				] ifFalse:[m eventHandler: handler].
				morphList at: i put: m].
		self addAllMorphs: morphList.
		self doLayout.
	].