trimTokenBags
	"Purge the bags so that they don't grow unbounded."

	categorizer keysAndValuesDo: [:categoryName :tokens | tokens removeAllButMostProminent: self maxTokenBagSize].
