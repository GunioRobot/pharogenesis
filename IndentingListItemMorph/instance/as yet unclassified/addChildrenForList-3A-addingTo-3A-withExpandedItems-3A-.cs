addChildrenForList: hostList addingTo: aCollection withExpandedItems: expandedItems

	| newChildren |

	firstChild ifNotNil: [
		firstChild withSiblingsDo: [ :aNode | aNode delete].
	].
	complexContents hasContents ifFalse: [^self].
	newChildren _ hostList 
		morphsFromCollection: complexContents contents 
		allowSorting: true
		withExpandedItems: expandedItems.
	firstChild _ newChildren first.
	firstChild withSiblingsDo: [ :aNode |
		aNode 
			indentLevel: indentLevel + 1;
			recomputeForList: hostList addingTo: aCollection withExpandedItems: expandedItems.
	].
	