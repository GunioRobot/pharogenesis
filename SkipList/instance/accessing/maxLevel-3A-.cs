maxLevel: n
	| newLevel oldPointers |
	newLevel _ n max: level.
	oldPointers _ pointers.
	pointers _ Array new: newLevel.
	splice _ Array new: newLevel.
	1 to: level do: [:i | pointers at: i put: (oldPointers at: i)]
