removeCornerGrips

	| corners |
	corners _ self submorphsSatisfying: [:each | each isKindOf: CornerGripMorph].
	corners do: [:each | each delete]