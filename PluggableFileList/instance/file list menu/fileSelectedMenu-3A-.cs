fileSelectedMenu: aMenu
	| firstItems secondItems thirdItems n1 n2 n3 services |
	firstItems _ self itemsForFile: self fullName asLowercase.
	secondItems _ self itemsForAnyFile.
	thirdItems _ self itemsForNoFile.
	n1 _ firstItems size.
	n2 _ n1 + secondItems size.
	n3 _ n2 + thirdItems size.
	services _ firstItems, secondItems, thirdItems, 
			(OrderedCollection with: (SimpleServiceEntry provider: self label: 'more...' selector: #offerAllFileOptions)).
	^ aMenu 
		addServices2: services 
		for: self
		extraLines: (Array with: n1 with: n2 with: n3)
