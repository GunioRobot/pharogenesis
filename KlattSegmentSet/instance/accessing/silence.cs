silence
	self phonemes do: [ :each | each isSilence ifTrue: [^ self at: each]].
	self error: 'silence segment not found'