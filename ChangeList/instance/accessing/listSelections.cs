listSelections
	listSelections ifNil: [
		list ifNotNil: [
			listSelections _ Array new: list size withAll: false]].
	^ listSelections