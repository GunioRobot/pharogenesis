onlyBoldItem: itemNumber
	"Set up emphasis such that all items are plain except for the given item number.  "

	emphases _ (Array new: selections size) atAllPut: nil.
	emphases at: itemNumber put: #bold