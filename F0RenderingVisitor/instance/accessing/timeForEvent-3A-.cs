timeForEvent: aVoiceEvent
	| time |
	time _ 0.
	clause eventsDo: [ :each | aVoiceEvent == each ifTrue: [^ time] ifFalse: [time _ time + each duration]]