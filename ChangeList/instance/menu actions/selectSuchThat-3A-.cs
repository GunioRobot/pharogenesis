selectSuchThat: aBlock
	"select all changes for which block returns true"
	listSelections _ changeList collect: [ :change | aBlock value: change ].
	self changed: #allSelections