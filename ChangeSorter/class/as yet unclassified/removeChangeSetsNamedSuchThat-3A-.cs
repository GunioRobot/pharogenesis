removeChangeSetsNamedSuchThat: nameBlock
	(ChangeSorter changeSetsNamedSuchThat: nameBlock)
		do: [:cs | AllChangeSets remove: cs wither]