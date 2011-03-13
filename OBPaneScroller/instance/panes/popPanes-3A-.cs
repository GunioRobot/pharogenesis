popPanes: count
	count * 2 timesRepeat: [transform removeMorph: transform lastSubmorph].
	panes removeLast: count