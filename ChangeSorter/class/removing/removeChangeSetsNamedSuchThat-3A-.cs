removeChangeSetsNamedSuchThat: nameBlock
	(ChangeSorter changeSetsNamedSuchThat: nameBlock)
		do: [:cs | self removeChangeSet: cs]