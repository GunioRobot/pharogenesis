setDefaultChangeSetCategory
	"Set a default ChangeSetCategory for the receiver, and answer it"

	^ changeSetCategory := self class changeSetCategoryNamed: #All