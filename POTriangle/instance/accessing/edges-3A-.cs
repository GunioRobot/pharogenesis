edges: anArray
	edges _ anArray.
	edges do: [:edge | edge face: self]