browseChangeSetsWithClass: class selector: selector
	| hits index |
	hits _ self gatherChangeSets select: 
		[:cs | (cs atSelector: selector class: class) ~~ #none].
	hits isEmpty ifTrue: [^ PopUpMenu notify: class name,'.',selector , '
is not in any change set'].
	index _ hits size == 1
		ifTrue:	[1]
		ifFalse:	[(PopUpMenu labelArray: (hits collect: [:cs | cs name])
					lines: #()) startUp].
	index = 0 ifTrue: [^ self].
	(ChangeSorter new myChangeSet: (hits at: index)) open.
