browseChangeSetsWithSelector: aSelector
	"Put up a list of all change sets that contain an addition, deletion, or change of any method with the given selector"

	| hits index |
	hits _ self allChangeSets select: 
		[:cs | cs hasAnyChangeForSelector: aSelector].
	hits isEmpty ifTrue: [^ self inform: aSelector , '
is not in any change set'].
	index _ hits size == 1
		ifTrue:	[1]
		ifFalse:	[(PopUpMenu labelArray: (hits collect: [:cs | cs name])
					lines: #()) startUp].
	index = 0 ifTrue: [^ self].
	(ChangeSetBrowser new myChangeSet: (hits at: index)) open

"ChangeSorter browseChangeSetsWithSelector: #clearPenTrails"
