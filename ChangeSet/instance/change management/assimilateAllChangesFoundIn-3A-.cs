assimilateAllChangesFoundIn: aChangeSet
	"Make all changes in aChangeSet take effect on self as it they happened later.  *** classes renamed in aChangeSet may have have problems"

	| cls info |
	aChangeSet changedClassNames do: [:className |
		(cls _ Smalltalk classNamed: className) notNil ifTrue:
		[info _ aChangeSet classChangeAt: className.
		info do: [:each | self atClass: cls add: each].

		info _ aChangeSet methodChanges at: className 
			ifAbsent: [Dictionary new].
		info associationsDo: [:assoc |
			assoc value == #remove ifTrue:
					[self removeSelector: assoc key class: cls]
				ifFalse: 
					[self atSelector: assoc key class: cls put: assoc value]]]].
	self flag: #developmentNote.  "the following cannot work, since the class will not exist; SW comments this out 8/91 because it thwarts integration!"
"aChangeSet classRemoves do:
		[:removed | self removeClass: (Smalltalk classNamed: removed)] "
