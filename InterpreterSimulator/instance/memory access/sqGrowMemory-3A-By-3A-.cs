sqGrowMemory: oldLimit By: delta
	Transcript show: 'grow memory from ', oldLimit printString, ' by ', delta printString; cr.
	memory _ memory copyGrownBy: delta // 4.
	^ memory size * 4