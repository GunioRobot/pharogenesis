onBlock: block
	"Open a profile browser on the given block, thereby running the block and 
	 collecting the message tally."
	"TimeProfileBrowser onBlock: [20 timesRepeat: 
			[Transcript show: 100 factorial printString]]"

	| inst result |
	inst := self new.
	inst block: block.
	result _ inst runBlock.
	self open: inst name: 'Time Profile'.
	^ result