peopleListIndex: newValue
	"Assign newValue to peopleListIndex."

	peopleListIndex = newValue ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	peopleListIndex _ newValue.
	self currentItem: (peopleListIndex ~= 0
						ifTrue: [peopleList at: peopleListIndex]
						ifFalse: [nil]).
	self changed: #peopleListIndex.