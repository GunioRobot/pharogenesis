type
	"This code attempts to reconstruct the type from its encoding in code.
		This allows one to test, for instance, (aNode type = LdInstType)."
	| type |
	self code < 0 ifTrue: [^ self code negated].
	self code < 256 ifFalse: [^ self code // 256].
	type _ CodeBases findFirst: [:one | self code < one].
	type = 0
		ifTrue: [^ 5]
		ifFalse: [^ type - 1]