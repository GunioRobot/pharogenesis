createRandomPassword

	| randomPass |
	randomPass _ String streamContents: [:stream | 10 timesRepeat: [ stream nextPut: 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789' atRandom]].
	self setNewPassword: randomPass.
	^randomPass