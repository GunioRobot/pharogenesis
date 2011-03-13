recTime

	self flag: #bob.		"not sent and no longer working"

	"| ms |
	ms _ 0.
	tape do:
		[:cell | ms _ ms + cell key].
	^ String streamContents:
		[:stream | (Time fromSeconds: ms // 1000) print24: true on: stream]"