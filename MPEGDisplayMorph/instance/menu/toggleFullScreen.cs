toggleFullScreen
	"Toggle the fullScreen flag."
	mpegFile isNil
		ifTrue: [^ self].
	mpegFile hasVideo
		ifFalse: [^ self].
	""
	self fullScreen: self fullScreen not.
	""
	"set screen size"
	self fullScreen
		ifTrue: [""
			self extent: Display extent.
			World activeHand newMouseFocus: self.
			self comeToFront]
		ifFalse: [self extent: self normalExtent].
	""
	(self fullScreen
			and: [self owner isKindOf: MPEGMoviePlayerMorph])
		ifTrue: [self owner position: -6 @ -6]
		ifFalse: [self owner == self world
				ifFalse: [self owner position: 0 @ 0] ifTrue:[self position:0@0]].
	""
	self nextFrame