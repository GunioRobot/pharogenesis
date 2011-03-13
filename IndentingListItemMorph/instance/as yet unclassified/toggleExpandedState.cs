toggleExpandedState

 	| newChildren toDelete c |

	isExpanded _ isExpanded not.
	toDelete _ OrderedCollection new.
	firstChild ifNotNil: [
		firstChild withSiblingsDo: [ :aNode | aNode recursiveAddTo: toDelete].
	].
	container noteRemovalOfAll: toDelete.
	(isExpanded and: [complexContents hasContents]) ifFalse: [
		^self changed
	].
	(c _ complexContents contents) isEmpty ifTrue: [^self changed].
	newChildren _ container 
		addSubmorphsAfter: self 
		fromCollection: c 
		allowSorting: true.
	firstChild _ newChildren first.
