upgradeCustomFilters
	"switch custom filters to named filters"
	CustomFilters keysAndValuesDo: [ :fname :code |
		NamedFilters at: fname asString put: (CelesteCodeFilter forCode: code) ].