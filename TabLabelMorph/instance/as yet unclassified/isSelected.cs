isSelected
	"Answer whether the tab is selected."

	^(self owner isKindOf: TabSelectorMorph) and: [
		self owner selectedTab == self]