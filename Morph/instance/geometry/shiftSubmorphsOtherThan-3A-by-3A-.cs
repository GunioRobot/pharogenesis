shiftSubmorphsOtherThan: listNotToShift by: delta
	| rejectList |
	rejectList _ listNotToShift ifNil: [OrderedCollection new].
	(submorphs copyWithoutAll: rejectList) do:
		[:m | m position: (m position + delta)]