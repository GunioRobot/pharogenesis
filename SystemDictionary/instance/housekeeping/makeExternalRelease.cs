makeExternalRelease		"Smalltalk makeExternalRelease"
	SystemOrganization removeCategoriesMatching: '*EToys*'.
	(self confirm: self version , '
Is this the correct version designation?
If not, choose no, and fix it.') ifFalse: [^ self].
	(Object classPool at: #DependentsFields) size > 1 ifTrue: [self halt].
	Browser initialize.
	Undeclared isEmpty ifFalse: [self halt].
	Smalltalk garbageCollect.
	self obsoleteClasses isEmpty ifFalse: [self halt].
	Symbol rehash.
	self halt: 'Ready to condense changes'.
	Smalltalk condenseChanges