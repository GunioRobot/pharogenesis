maxExtent: listOfStrings

	| h w maxW f |
	maxW _ 0.
	listOfStrings do: [:str |
		f _ self fontToUse.
		w _ f widthOfString: str.
		h _ f height.
		maxW _ maxW max: w].
	self extent: (maxW + 4 + h) @ (h + 4).
	self changed