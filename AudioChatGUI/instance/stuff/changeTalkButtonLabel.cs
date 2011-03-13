changeTalkButtonLabel

	| bText |
	self transmitWhileRecording.
	handsFreeTalking ifTrue: [
		theTalkButton
			labelUp: 'Talk';
			labelDown: 'Release';
			label: 'Talk'.
		bText _ 'Click once to begin a message. Click again to end the message.'
	] ifFalse: [
		theTalkButton
			labelUp: 'Talk';
			labelDown: (transmitWhileRecording ifTrue: ['TALKING'] ifFalse: ['RECORDING']);
			label: 'Talk'.
		bText _ 'Press and hold to record a message.'
	].
	transmitWhileRecording ifTrue: [
		bText _ bText , ' The message will be sent while you are speaking.'
	] ifFalse: [
		bText _ bText , ' The message will be sent when you are finished.'
	].
	theTalkButton setBalloonText: bText.
