upTo: max do: aBlock
	"Special enumeration message so the client can modify the vertices"
	| vtx |
	1 to: max do:[:i|
		vtx _ self at: i.
		aBlock value: vtx.
		self at: i put: vtx].