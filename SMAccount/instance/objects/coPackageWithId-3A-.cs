coPackageWithId: anIdString
	"Return the correct package or nil."

	| uuid |
	uuid _ UUID fromString: anIdString.
	^self coPackages detect: [:p | p id = uuid ] ifNone: [nil]