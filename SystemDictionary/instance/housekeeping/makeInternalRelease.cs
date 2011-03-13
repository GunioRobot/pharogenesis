makeInternalRelease
	"Smalltalk makeInternalRelease"
	(self confirm: SystemVersion current version , '
Is this the correct version designation?
If not, choose no, and fix it.')
		ifFalse: [^ self].
	(Object classPool at: #DependentsFields) size > 1
		ifTrue: [self halt].
	Smalltalk at: #Browser ifPresent:[:br| br initialize].
	Undeclared isEmpty
		ifFalse: [self halt].
	self garbageCollect.
	self obsoleteClasses isEmpty
		ifFalse: [self halt].
	Symbol rehash.
	self halt: 'Ready to condense changes'.
	self condenseChanges