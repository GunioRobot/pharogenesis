toggleExpandedState

 	| newChildren toDelete |

	isExpanded _ isExpanded not.
	toDelete _ OrderedCollection new.
	firstChild ifNotNil: [
		firstChild withSiblingsDo: [ :aNode | aNode recursiveAddTo: toDelete].
	].
	owner removeAllMorphsIn: toDelete.
	(isExpanded and: [complexContents hasContents]) ifFalse: [
		^self changed
	].
	newChildren _ container 
		addSubmorphsAfter: self 
		fromCollection: complexContents contents 
		allowSorting: true.
	firstChild _ newChildren first.
	firstChild withSiblingsDo: [ :aNode |
		aNode indentLevel: indentLevel + 1.
	].
