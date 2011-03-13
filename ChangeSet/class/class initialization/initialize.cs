initialize
	"ChangeSet initialize"
	AllChangeSets == nil ifTrue:
		[AllChangeSets _ OrderedCollection new].
	self gatherChangeSets.
	FileServices registerFileReader: self.
