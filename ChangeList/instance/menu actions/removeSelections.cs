removeSelections
	"Remove the selected items from the receiver.  9/18/96 sw"

	| newChangeList newList |

	newChangeList _ OrderedCollection new.
	newList _ OrderedCollection new.

	1 to: changeList size do:
		[:i | (listSelections at: i) ifFalse:
			[newChangeList add: (changeList at: i).
			newList add: (list at: i)]].
	newChangeList size < changeList size
		ifTrue:
			[changeList _ newChangeList.
			list _ newList.
			listIndex _ 0.
			listSelections _ Array new: list size withAll: false].
	self changed: #list

	