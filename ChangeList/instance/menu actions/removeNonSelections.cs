removeNonSelections
	"Remove the unselected items from the receiver."

	| newChangeList newList |

	newChangeList _ OrderedCollection new.
	newList _ OrderedCollection new.

	1 to: changeList size do:
		[:i | (listSelections at: i) ifTrue:
			[newChangeList add: (changeList at: i).
			newList add: (list at: i)]].
	newChangeList size == 0 ifTrue:
		[^ self inform: 'That would remove everything.
Why would you want to do that?'].

	newChangeList size < changeList size
		ifTrue:
			[changeList _ newChangeList.
			list _ newList.
			listIndex _ 0.
			listSelections _ Array new: list size withAll: false].
	self changed: #list

	