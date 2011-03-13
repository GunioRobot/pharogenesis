createRandomPassword
	"Create a random password and set it
	in parallell to the regular one."

	| randomPass |
	randomPass := String streamContents: [:stream | 10 timesRepeat: [ stream nextPut: 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789' atRandom]].
	self setNewPassword: randomPass.
	^randomPass