log: pieces to: request
	| tab |
	tab := String with: Character tab.
	request log: ((Time now printString), tab, (Date today printString), tab, (pieces printString),
	Character cr asString).

