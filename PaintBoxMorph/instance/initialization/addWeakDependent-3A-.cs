addWeakDependent: anObject

	weakDependents ifNil: [^weakDependents _ WeakArray with: anObject].
	weakDependents _ weakDependents,{anObject} reject: [ :each | each isNil].