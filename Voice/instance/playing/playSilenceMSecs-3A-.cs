playSilenceMSecs: msecs
	Transcript cr; show: 'silence ', msecs printString, 'msecs'.
	sound isNil ifTrue: [^ self].
	sound add: (RestSound dur: msecs / 1000.0)