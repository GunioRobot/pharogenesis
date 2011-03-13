explainMySel: symbol 
	"1/15/96 sw"

	| lits classes |
	self flag: #noteToTed.  "a halting piece of the generic-explain attempt."

	classes _ Smalltalk allClassesImplementing: symbol.
	^ classes size > 0
		ifTrue: ['Smalltalk browseAllImplementorsOf: #', symbol]
		ifFalse: [nil]