initializeWith: aWonderland
	"Initialize this instance."

	myWonderland _ aWonderland.
	actorListIndex _ 0.
	selectedActor _ nil.
	actorViewer _ nil.

	myListMorph _ (PluggableListMorph on: self list: #actorList
						selected: #actorListIndex changeSelected: #actorListIndex:
						menu: #actorMenu: keystroke: #systemCatListKey:from:).
	myListMorph name: 'Actors'.
	myListMorph scrollBarOnLeft: false.
	myListMorph extent: 140@320.
	myListMorph color: (Color r: 0.627 g: 0.909 b: 0.972).
	myListMorph retractable: false.
