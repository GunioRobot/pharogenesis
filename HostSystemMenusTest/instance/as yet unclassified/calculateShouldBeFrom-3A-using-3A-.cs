calculateShouldBeFrom: item using: c
	| |
	
	item replaceAll: $; with: Character space.
	item replaceAll: $^ with: Character space.
	item replaceAll: $! with: Character space.
	item replaceAll: $< with: Character space.
	item replaceAll: $/ with: Character space.
	^self calculateShouldBeFrom2ndLevel: item using: c