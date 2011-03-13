maxLevel: n
	| newLevel oldPointers |
	newLevel := n max: level.
	oldPointers := pointers.
	pointers := Array new: newLevel.
	splice := Array new: newLevel.
	1 to: level do: [:i | pointers at: i put: (oldPointers at: i)]
