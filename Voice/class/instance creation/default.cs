default
	self voices isEmpty ifTrue: [^ KlattVoice new].
	^ self voices detect: [ :one | one name = 'Kurt']
		ifNone: [self voices detect: [ :one | one samplingRate >= 16000]
					ifNone: [self voices anyOne]]