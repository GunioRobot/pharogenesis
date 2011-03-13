treeString
	"Return a indented String showing the tree
	structure of all possible scenarios."

	^String streamContents: [:s |
		self treeStringOn: s indent: 0]