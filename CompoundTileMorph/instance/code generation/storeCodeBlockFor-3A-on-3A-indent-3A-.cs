storeCodeBlockFor: scriptPart on: aStream indent: tabCount

	| rows r |
	rows _ scriptPart tileRows.
	1 to: rows size do: [:i |
		tabCount timesRepeat: [aStream tab].
		r _ rows at: i.
		r do: [:t | t storeCodeOn: aStream indent: tabCount].
		i < rows size ifTrue: [aStream nextPut: $.; cr]].
