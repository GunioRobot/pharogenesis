okayToRemove
	| aName |
	aName _ self name.
	self == Smalltalk changes ifTrue:
		[self inform: 'Cannot remove "', aName, '"
because it is the 
current change set.'.
		^ false].

	self belongsToAProject ifTrue:
		[self inform: 'Cannot remove "', aName, '" 
because it belongs to a 
project.'.
			^ false].

	^ true
