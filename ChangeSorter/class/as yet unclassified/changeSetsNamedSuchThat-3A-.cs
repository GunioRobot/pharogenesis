changeSetsNamedSuchThat: nameBlock
	"(ChangeSorter changeSetsNamedSuchThat:
		[:name | name first isDigit and: [name initialInteger >= 373]])
		do: [:cs | AllChangeSets remove: cs wither]"

	self gatherChangeSets.
	^ AllChangeSets select: [:aChangeSet | nameBlock value: aChangeSet name]