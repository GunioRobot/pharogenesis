sortInitialFaces
	faces _ faces sortBy:[:face1 :face2| (vertices at: face1 p1Index) sortsBefore: (vertices at: face2 p1Index)].