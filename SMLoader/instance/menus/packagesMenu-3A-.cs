packagesMenu: aMenu 
	"Answer the packages-list menu."

	self selectedPackageOrRelease 
		ifNotNil: [aMenu addList: self packageSpecificOptions; addLine].
	aMenu addList: self generalOptions.
	self addFiltersToMenu: aMenu.
	^aMenu