removeDoIts
	"Remove doits from the receiver, other than initializes. 1/26/96 sw"

	| newChangeList newList |

	newChangeList _ OrderedCollection new.
	newList _ OrderedCollection new.

	changeList with: list do:
		[:chRec :str |
			(chRec type ~~ #doIt or:
				[str endsWith: 'initialize'])
					ifTrue:
						[newChangeList add: chRec.
						newList add: str]].
	newChangeList size < changeList size
		ifTrue:
			[changeList _ newChangeList.
			list _ newList.
			listIndex _ 0.
			listSelections _ Array new: list size withAll: false].
	self changed: #list.

	