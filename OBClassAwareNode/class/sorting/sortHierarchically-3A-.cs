sortHierarchically: nodes
	nodes do: [:a | nodes do: [:b | a adoptSuperior: b]].
	nodes sort: [:a : b | a sortsBefore: b].
	^ nodes