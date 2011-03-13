allAliasesDict
	| dict |
	dict _ super allAliasesDict.
	self aliases do: [:assoc |
		dict at: assoc key put: assoc value].
	^dict