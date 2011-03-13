sortSubmorphsBy: sortOrderSymbol
	"Sort the receiver's submorphs by the criterion indicated in the provided symbol"
	self invalidRect: self fullBounds.
	submorphs _ submorphs sortBy:[:a :b | (a perform: sortOrderSymbol) <= (b perform: sortOrderSymbol)].
	self layoutChanged.