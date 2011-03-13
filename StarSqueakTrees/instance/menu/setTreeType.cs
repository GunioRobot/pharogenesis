setTreeType

	| menu choice |
	menu := CustomMenu new title: 'Choose tree type:'.
	menu add: 'tree1' action: #tree1.
	menu add: 'tree2' action: #tree2.
	choice := menu startUp.
	choice ifNotNil: [
		treeTypeSelector := choice.
		self startOver].
