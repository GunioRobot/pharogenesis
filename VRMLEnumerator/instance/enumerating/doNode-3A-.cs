doNode: aVRMLNode
	| action |
	action := EnumActions at: aVRMLNode name ifAbsent:[nil].
	action ifNotNil:[self perform: action with: aVRMLNode].