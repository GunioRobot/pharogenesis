selectionChanged
	self paragraph selectionRects do: [:r | self invalidRect: r]