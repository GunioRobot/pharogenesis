allNames

	| names |
	names _ OrderedCollection new.
	self allInstancesDo: [:proj |
		proj == CurrentProject ifFalse: [names add: proj name]].
	^ names
