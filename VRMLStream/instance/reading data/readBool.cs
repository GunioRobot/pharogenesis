readBool
	| string bool |
	self backup.
	string := self readName.
	string = 'TRUE' ifTrue:[bool := true].
	string = 'FALSE' ifTrue:[bool := false].
	self restoreIf: bool isNil.
	^bool