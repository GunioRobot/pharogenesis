newFrom: aCollection 
	"Answer an instance of me containing the same elements as aCollection."

	^ (aCollection as: MultiString) asMultiSymbol

"	MultiSymbol newFrom: {$P. $e. $n}
	{$P. $e. $n} as: MultiSymbol
"
