upTo: max doWithIndex: aBlock
	"Special enumeration message so the client can modify the vertices"
	| vtx |
	1 to: max do:[:i|
		vtx _ self at: i.
		aBlock value: vtx value: i.
		self at: i put: vtx].