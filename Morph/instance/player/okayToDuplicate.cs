okayToDuplicate
	self player ifNil: [^ true].
	self instantiatedUserScriptsDo:
		[:aScript | aScript isAnonymous ifTrue:
			[self inform: 'This object has one or more
unnamed, unsaved scripts,
which would not be part
of a duplicate.  So, for now,
we just won''t let you do
this.  Sorry!'.
			^ false]].

	^ true