itemsForFileEnding: suffix
	| labels lines selectors |
	labels _ OrderedCollection new.
	lines _ OrderedCollection new.
	selectors _ OrderedCollection new.
	^ Array with: labels with: lines with: selectors