offerAllFileOptions
	| items action |
	items _ self itemsForFileEnding: '*'.
	action _ (SelectionMenu labels: items first lines: items second selections: items third)
			startUp.
	action ifNotNil: [self perform: action]