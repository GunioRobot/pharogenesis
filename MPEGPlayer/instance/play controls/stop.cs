stop
	self videoPlayerProcess notNil ifTrue: 
		[self videoPlayerProcess terminate. 
		self videoPlayerProcess: nil].
	self audioPlayerProcess notNil ifTrue: 
		[self audioPlayerProcess terminate. 
		self audioPlayerProcess: nil.
		SoundPlayer stopPlayingAll]