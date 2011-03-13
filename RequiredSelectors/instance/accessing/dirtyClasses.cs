dirtyClasses
	dirtyClasses ifNil: [dirtyClasses := WeakSet new].
	^dirtyClasses