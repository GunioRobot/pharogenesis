scoreFromURL: urlString

	| data score |
	data _ (HTTPSocket httpGet: urlString) contents asByteArray.
	score _ (self new readMIDIFrom: (ReadStream on: data)) asScore.
	^ score
