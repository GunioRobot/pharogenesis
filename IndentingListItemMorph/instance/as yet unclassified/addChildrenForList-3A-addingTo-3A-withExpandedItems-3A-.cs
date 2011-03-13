addChildrenForList: hostList addingTo: morphList withExpandedItems: expandedItems

	firstChild ifNotNil: [
		firstChild withSiblingsDo: [ :aNode | aNode delete].
	].
	firstChild _ nil.
	complexContents hasContents ifFalse: [^self].
	firstChild _ hostList 
		addMorphsTo: morphList
		from: complexContents contents 
		allowSorting: true
		withExpandedItems: expandedItems
		atLevel: indentLevel + 1.
	