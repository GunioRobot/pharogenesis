uniClasesDo: aBlock
	"Examine structures and execute the block with each instance-specific class"

	| cls |
	structures keysDo: [:clsName | 
		(cls _ Smalltalk at: clsName) isSystemDefined ifFalse: [aBlock value: cls]]