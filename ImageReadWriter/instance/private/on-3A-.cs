on: aStream

	(stream _ aStream) reset.
	(stream respondsTo: #binary) ifTrue: [stream binary].
		"Note that 'reset' makes a file be text!  Must do this
after!"
