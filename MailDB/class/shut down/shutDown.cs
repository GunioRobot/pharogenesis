shutDown
	"snapshot all mail databases to disk"

	self allSubInstancesDo: [:db | db saveDB]