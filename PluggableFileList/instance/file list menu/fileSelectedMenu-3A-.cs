fileSelectedMenu: aMenu
	| firstItems secondItems thirdItems n1 n2 n3 |
	firstItems _ self itemsForFileEnding: self fileNameSuffix asLowercase.
	secondItems _ self itemsForAnyFile.
	thirdItems _ self itemsForNoFile.
	n1 _ firstItems first size.
	n2 _ n1 + secondItems first size.
	n3 _ n2 + thirdItems first size.
	^ aMenu
		labels: firstItems first , secondItems first , thirdItems first
		lines: firstItems second
				, (Array with: n1 with: n2)
				, (thirdItems second collect: [:n | n + n2])
				, (Array with: n3)
		selections: firstItems third , secondItems third , thirdItems third