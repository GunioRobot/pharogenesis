writeScanOn: strm

	kern > 0 ifTrue: [
		kern do: [:kk | strm nextPut: $+]].
	kern < 0 ifTrue: [
		0-kern do: [:kk | strm nextPut: $-]].