useWeakArrayTables "Symbol useWeakArrayTables"
	"Use weak arrays for referencing the symbols"
	SelectorTables _ SelectorTables collect:[:table| 
			table collect:[:subTable| subTable as: WeakArray]].
	OtherTable _ OtherTable collect:[:table| table as: WeakArray].