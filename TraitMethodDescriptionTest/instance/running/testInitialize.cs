testInitialize
	| empty |
	empty _ TraitMethodDescription new.
	self assert: empty isEmpty.
	self deny: empty isConflict.
	self deny: empty isProvided.
	self deny: empty isRequired