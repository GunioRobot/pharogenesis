readCharacter: aBits from: aStream

	| pos |
	pos _ 0.
	12 timesRepeat: [
		1 to: 2 do: [ :w |
			aBits byteAt: (pos+w) put: (aStream next ). 
		].
		pos _ pos + 4.
	].
