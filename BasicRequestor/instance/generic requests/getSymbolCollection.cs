getSymbolCollection
	^[self getStringCollection collect: [:each | each asSymbol]] 
		on: ServiceCancelled
		do: [#()]