compact
	"Salvage and Compact the messages file."

	| stats |
	mailDB ifNil: [ ^self ].
	Transcript cr; show: 'Compacting message file...'.
	Cursor execute showWhile: [stats _ mailDB compact].
	Transcript show: 'Done.'; cr.
	Transcript show:
		'Recovered ',
		(stats at: 1) printString, ' message',
		(((stats at: 1) = 1) ifTrue: [', '] ifFalse: ['s, ']),
		(stats at: 2) printString, ' bytes.  ',
		(stats at: 3) printString, ' active messages remain.'; cr.

	self updateTOC