changeEmphasis

	| reply aList |
	aList _ #(normal bold italic narrow underlined struckOut).
	reply _ (SelectionMenu labelList: (aList collect: [:t | t translated]) selections: aList) startUp.
	reply ifNotNil:[
		self emphasis: (TextEmphasis perform: reply) emphasisCode.
	].
