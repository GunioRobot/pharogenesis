selectionChanged: ann
	| node actions |
	morph removeAllMorphs.
	node _ browser currentNode ifNil: [^ self].
	actions _ (node metaNode actionsForNode: node) select: [:ea | ea wantsButton].
	actions do: [:ea | morph addMorphBack: ea buttonMorph]