doAndCollect

	self do: [ :j | j isEmpty ifFalse: [j size]].
	self collect: [ :each | each asString withBlanksTrimmed].
	