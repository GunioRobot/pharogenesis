recTime
	| ms |
	ms _ 0.
	tape do:
		[:cell | ms _ ms + cell key].
	^ String streamContents:
		[:stream | (Time fromSeconds: ms // 1000) print24: true on: stream]