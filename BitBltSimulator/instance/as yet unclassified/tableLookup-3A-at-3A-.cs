tableLookup: table at: index

	^ interpreterProxy longAt: (table + (index * 4))