mouseOverList: evt rank: rank 
	"With rank = 1, returns a list consisting of the topmost unlocked morph in the
	innermost frame (pasteUp), and all of its containers in that frame.
	With rank = 2, returns the smae kind of list, but rooted in the next lower
	rootmorph.  This can be useful to get mouseOvers below an active halo."
	| p roots mList mm r |
	p _ evt cursorPoint.
	roots _ self world rootMorphsAt: p.  "root morphs in world"
	roots size >= rank
		ifTrue: [mList _ (roots at: rank) unlockedMorphsAt: p.
				mList size > 0 ifTrue:
					["NOTE: We really only want the top morph and all its owners"
					mm _ mList first.  r _ roots at: rank.
					mList _ OrderedCollection new.
					[mm == r] whileFalse:
						[mList addLast: mm.
						mm _ mm owner].
					mList add: r]]
		ifFalse: [mList _ EmptyArray].
	^ mList