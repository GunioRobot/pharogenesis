servicesForKeystroke: aChar
	| scan |
	scan _ self announcer announce: OBServiceScan.
	^ scan services select: [:ea | ea keystroke == aChar]