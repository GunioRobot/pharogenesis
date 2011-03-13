timeForEvent: aVoiceEvent
	| time |
	time := 0.
	clause eventsDo: [ :each | aVoiceEvent == each ifTrue: [^ time] ifFalse: [time := time + each duration]]