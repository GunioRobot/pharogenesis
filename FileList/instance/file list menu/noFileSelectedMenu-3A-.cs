noFileSelectedMenu: aMenu
	| items |
	items _ self itemsForNoFile.
	^ aMenu
		labels: items first
		lines: items second
		selections: items third
