filterScanline: filterType count: count
	| filter |
	filter _ #(filterNone: filterHorizontal: filterVertical:
filterAverage: filterPaeth:)
		at: filterType+1.
	self perform: filter asSymbol with: count.

