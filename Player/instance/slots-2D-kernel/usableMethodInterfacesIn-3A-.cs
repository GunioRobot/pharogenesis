usableMethodInterfacesIn: methodInterfaceList
	"Filter the list given by methodInterfaceList, to remove items inappropriate to the receiver"

	self hasCostumeThatIsAWorld ifTrue:
		"Formerly we had been hugely restrictive here, but let's try the other extreme for a while..."
		[^ methodInterfaceList reject: [:anInterface |
			#()  includes: anInterface selector]].

	self hasAnyBorderedCostumes ifTrue: [^ methodInterfaceList].

	^ self hasOnlySketchCostumes
		ifTrue:
			[methodInterfaceList select: [:anInterface | (#(getColor getSecondColor getBorderColor getBorderWidth getBorderStyle  getRoundedCorners getUseGradientFill getRadialGradientFill ) includes: anInterface selector) not]]
		ifFalse:
			[methodInterfaceList select: [:anInterface | (#(getBorderColor getBorderWidth) includes: anInterface selector) not]]