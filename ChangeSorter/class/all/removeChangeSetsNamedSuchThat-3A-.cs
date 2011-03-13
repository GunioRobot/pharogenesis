removeChangeSetsNamedSuchThat: nameBlock
	"ChangeSorter removeChangeSetsNamedSuchThat:
		[:name | name first isDigit and: [name initialInteger >= 275]]"
	self allChangeSetNames do:
		[:csName | (nameBlock value: csName) ifTrue: [AllChangeSets remove: (self changeSetNamed: csName) wither]]