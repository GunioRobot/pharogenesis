createHuffmanTables: values counts: counts from: minBits to: maxBits
	"Create the actual tables"
	| table tableStart tableSize tableEnd 
	valueIndex tableStack numValues deltaBits maxEntries
	lastTable lastTableStart tableIndex lastTableIndex |

	table _ WordArray new: ((4 bitShift: minBits) max: 16).

	"Create the first entry - this is a dummy.
	It gives us information about how many bits to fetch initially."
	table at: 1 put: (minBits bitShift: 24) + 2. "First actual table starts at index 2"

	"Create the first table from scratch."
	tableStart _ 2. "See above"
	tableSize _ 1 bitShift: minBits.
	tableEnd _ tableStart + tableSize.
	"Store the terminal symbols"
	valueIndex _ (counts at: minBits+1).
	tableIndex _ 0.
	1 to: valueIndex do:[:i|
		table at: tableStart + tableIndex put: (values at: i).
		tableIndex _ tableIndex + 1].
	"Fill up remaining entries with invalid entries"
	tableStack _ OrderedCollection new: 10. "Should be more than enough"
	tableStack addLast: 
		(Array 
			with: minBits	"Number of bits (e.g., depth) for this table"
			with: tableStart	"Start of table"
			with: tableIndex "Next index in table"
			with: minBits	"Number of delta bits encoded in table"
			with: tableSize - valueIndex "Entries remaining in table").
	"Go to next value index"
	valueIndex _ valueIndex + 1.
	"Walk over remaining bit lengths and create new subtables"
	minBits+1 to: maxBits do:[:bits|
		numValues _ counts at: bits+1.
		[numValues > 0] whileTrue:["Create a new subtable"
			lastTable _ tableStack last.
			lastTableStart _ lastTable at: 2.
			lastTableIndex _ lastTable at: 3.
			deltaBits _ bits - (lastTable at: 1).
			"Make up a table of deltaBits size"
			tableSize _ 1 bitShift: deltaBits.
			tableStart _ tableEnd.
			tableEnd _ tableEnd + tableSize.
			[tableEnd > table size ]
				whileTrue:[table _ self growHuffmanTable: table].
			"Connect to last table"
			self assert:[(table at: lastTableStart + lastTableIndex) = 0]."Entry must be unused"
			table at: lastTableStart + lastTableIndex put: (deltaBits bitShift: 24) + tableStart.
			lastTable at: 3 put: lastTableIndex+1.
			lastTable at: 5 put: (lastTable at: 5) - 1.
			self assert:[(lastTable at: 5) >= 0]. "Don't exceed tableSize"
			"Store terminal values"
			maxEntries _ numValues min: tableSize.
			tableIndex _ 0.
			1 to: maxEntries do:[:i|
				table at: tableStart + tableIndex put: (values at: valueIndex).
				valueIndex _ valueIndex + 1.
				numValues _ numValues - 1.
				tableIndex _ tableIndex+1].
			"Check if we have filled up the current table completely"
			maxEntries = tableSize ifTrue:[
				"Table has been filled. Back up to the last table with space left."
				[tableStack isEmpty not and:[(tableStack last at: 5) = 0]]
						whileTrue:[tableStack removeLast].
			] ifFalse:[
				"Table not yet filled. Put it back on the stack."
				tableStack addLast:
					(Array
						with: bits		"Nr. of bits in this table"
						with: tableStart	"Start of table"
						with: tableIndex "Index in table"
						with: deltaBits	"delta bits of table"
						with: tableSize - maxEntries "Unused entries in table").
			].
		].
	].
	 ^table copyFrom: 1 to: tableEnd-1