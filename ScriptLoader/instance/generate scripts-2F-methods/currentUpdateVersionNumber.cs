currentUpdateVersionNumber
	^ CurrentUpdateVersionNumber ifNil: [SystemVersion current highestUpdate]