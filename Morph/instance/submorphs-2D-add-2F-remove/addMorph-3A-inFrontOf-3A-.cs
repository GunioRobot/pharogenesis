addMorph: newMorph inFrontOf: aMorph
	"Add a morph to the list of submorphs in front of the specified morph"

	| newSubmorphs index |

	newMorph owner ifNotNil: [newMorph owner privateRemoveMorph: newMorph].
	newMorph layoutChanged.
	newMorph privateOwner: self.

	newSubmorphs _ submorphs species new: submorphs size + 1.

	index _ 1.

	[ (submorphs at: index) = aMorph ]
		whileFalse: [ newSubmorphs at: index put: (submorphs at: index).
					  index _ index + 1 ].

	newSubmorphs at: index put: newMorph.

	newSubmorphs
		replaceFrom: (index + 1)
		to: newSubmorphs size
		with: submorphs
		startingAt: index.

	submorphs _ newSubmorphs.
	newMorph changed.
	self layoutChanged.
