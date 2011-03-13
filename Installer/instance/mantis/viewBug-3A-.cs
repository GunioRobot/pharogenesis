viewBug: aBugNo

	^Workspace new contents: (self bug: aBugNo); openLabel: ('Mantis ', aBugNo printString).
