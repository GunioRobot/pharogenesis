asHex
	| stream |
	stream _ WriteStream on: (String new: self size * 4).
	self do: [ :ch | stream nextPutAll: ch hex ].
	^stream contents