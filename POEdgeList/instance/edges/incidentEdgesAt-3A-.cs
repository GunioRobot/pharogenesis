incidentEdgesAt: aVertex 
	^ self halfedges select: [:edge | edge origin = aVertex]