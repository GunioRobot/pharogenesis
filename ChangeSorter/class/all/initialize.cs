initialize
	AllChangeSets == nil ifTrue:
		[AllChangeSets _ OrderedCollection new].
	self gatherChangeSets.
	self initializeMenus

	"
	ChangeSorter initialize.
	GeneralListController allInstancesDo:
		[:each  | each model parent class == ChangeSorter ifTrue:
			[each yellowButtonMenu: ClassMenu 
				yellowButtonMessages: ClassSelectors.
			each yellowButtonMenu: MsgListMenu 
				yellowButtonMessages: MsgListSelectors]].
	"