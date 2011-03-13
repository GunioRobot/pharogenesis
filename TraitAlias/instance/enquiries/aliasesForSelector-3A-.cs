aliasesForSelector: aSymbol
	| selectors |
	selectors _ self aliases
		select: [:association | association value = aSymbol]
		thenCollect: [:association | association key].
	^(super aliasesForSelector: aSymbol)
		addAll: selectors;
		yourself
		 