removeOlderMethodVersions
	"Remove older versions of entries from the receiver."
	| newChangeList newList found str |
	newChangeList _ OrderedCollection new.
	newList _ OrderedCollection new.
	found _ OrderedCollection new.

	changeList reverseWith: list do:
		[:chRec :strNstamp | str _ strNstamp copyUpTo: $;.
			(found includes: str)
				ifFalse:
					[found add: str.
					newChangeList add: chRec.
					newList add: strNstamp]].
	newChangeList size < changeList size
		ifTrue:
			[changeList _ newChangeList reversed.
			list _ newList reversed.
			listIndex _ 0.
			listSelections _ Array new: list size withAll: false].
	self changed: #list