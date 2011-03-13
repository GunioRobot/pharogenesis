removeOlderMethodVersions
	"Remove older versions of entries from the receiver."
	| newChangeList newList found str |
	newChangeList := OrderedCollection new.
	newList := OrderedCollection new.
	found := OrderedCollection new.

	changeList reverseWith: list do:
		[:chRec :strNstamp | str := strNstamp copyUpTo: $;.
			(found includes: str)
				ifFalse:
					[found add: str.
					newChangeList add: chRec.
					newList add: strNstamp]].
	newChangeList size < changeList size
		ifTrue:
			[changeList := newChangeList reversed.
			list := newList reversed.
			listIndex := 0.
			listSelections := Array new: list size withAll: false].
	self changed: #list