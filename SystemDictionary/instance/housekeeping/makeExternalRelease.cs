makeExternalRelease		"Smalltalk makeExternalRelease"
	(self confirm: self version , '
Is this the correct version designation?
If not, choose no, and fix it.') ifFalse: [^ self].
	(Object classPool at: #DependentsFields) size > 1 ifTrue: [self halt].
	Browser initialize.
	Undeclared isEmpty ifFalse: [self halt].
	Smalltalk garbageCollect.
	self obsoleteClasses isEmpty ifFalse: [self halt].
	Display newDepth: 8.
	Project allInstancesDo: [:p | p displayDepth: 8].
	EToySystem prepareForExternalReleaseNamed: 'Squeak2.0'.
	Utilities removeDisney.
	EToySystem class removeSelector: #serverUrls.
	Utilities removeDisney.
	#(Helvetica Palatino ComicAll) do:
		[:k | TextConstants removeKey: k].
	EToySystem class removeSelector: #serverUrls.
	SystemDictionary removeSelector: #makeExternalRelease.
	Symbol rehash.
	self halt: 'Ready to condense sources'.
	Smalltalk condenseSources