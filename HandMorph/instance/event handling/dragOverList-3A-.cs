dragOverList: evt
	| p roots mList mm root |
	p _ evt cursorPoint.
	roots _ self world rootMorphsAt: p.  "root morphs in world"
	roots isEmpty
		ifTrue: [^EmptyArray]
		ifFalse: [root _ roots first].
	mList _ root morphsAt: p.
	mList size > 0 ifTrue:
		["NOTE: We really only want the top morph and all its owners"
		mm _ mList first.
		mList _ OrderedCollection new.
		[mm == root] whileFalse:
			[mList addLast: mm.
			mm _ mm owner].
		mList add: root].
	^ mList