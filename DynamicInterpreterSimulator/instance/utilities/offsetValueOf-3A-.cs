offsetValueOf: offsetObject
	"Overridden in the simulator since we can't store negative integers into the memory.
	Note: a bias of 16r20000000 avoids LargeInteger arithmetic."

	| offset |
	self assertIsIntegerObject: offsetObject.
	offset _ offsetObject - 16r20000000 - 1.
	self assert: (offset < (1024 * 8) and: [offset > (-1024 * 8)]).
	^offset