scoreFromURL: urlString

	| data |
	data _ HTTPSocket httpGet: urlString accept: 'audio/midi'.
	data binary.
	^ (self new readMIDIFrom: data) asScore.
