setTreeType

	| menu choice |
	menu _ CustomMenu new title: 'Choose tree type:'.
	menu add: 'tree1' action: #tree1.
	menu add: 'tree2' action: #tree2.
	choice _ menu startUp.
	choice ifNotNil: [
		treeTypeSelector _ choice.
		self startOver].
