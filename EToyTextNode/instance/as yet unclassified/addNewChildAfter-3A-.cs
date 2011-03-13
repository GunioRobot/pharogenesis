addNewChildAfter: anotherOrNilOrZero

	| where newNode |

	anotherOrNilOrZero == 0 ifTrue: [
		newNode _ EToyTextNode newNode.
		children _ {newNode} asOrderedCollection,children.
		^newNode
	].
	where _ children indexOf: anotherOrNilOrZero ifAbsent: [children size].
	children add: (newNode _ EToyTextNode newNode) afterIndex: where.
	^newNode
