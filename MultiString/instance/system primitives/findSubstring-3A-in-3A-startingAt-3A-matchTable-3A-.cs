findSubstring: key in: body startingAt: start matchTable: matchTable

	^ self findMultiSubstring: key asMultiString in: body asMultiString startingAt: start matchTable: matchTable.
