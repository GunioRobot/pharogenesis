useArrayTables	"Symbol useArrayTables"
	"Use arrays for referencing the symbols"
	SelectorTables _ SelectorTables collect:[:table| 
			table collect:[:subTable| (subTable as: Array) copyWithout: nil]].
	OtherTable _ OtherTable collect:[:table| (table as: Array) copyWithout: nil].