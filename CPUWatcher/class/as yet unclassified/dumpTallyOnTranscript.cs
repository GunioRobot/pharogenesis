dumpTallyOnTranscript
	self current ifNotNil: [
		ProcessBrowser dumpTallyOnTranscript: self current tally
	]