compact
	"Compact the messages file."

	| stats |
	Transcript cr; show: 'Compacting message file...'.
	Cursor execute showWhile: [stats _ mailDB compact].
	Transcript show: 'Done.'; cr.
	Transcript show:
		'Recovered ',
		(stats at: 1) printString, ' message',
		(((stats at: 1) > 1) ifTrue: ['s, '] ifFalse: [', ']),
		(stats at: 2) printString, ' bytes.'; cr.