scaleQuantizationTable: table

	| index |

	index _ 1.
	1 to: DCTSize do:
		[:row |
		1 to: DCTSize do:
			[:col |
			table at: index
				put: ((table at: index) * (QTableScaleFactor at: row) *
					(QTableScaleFactor at: col)) rounded.
			index _ index + 1]].
	^ table
