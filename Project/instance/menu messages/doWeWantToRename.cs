doWeWantToRename

	| want |

	self hasBadNameForStoring ifTrue: [^true].
	(self name beginsWith: 'Unnamed') ifTrue: [^true].
	want _ world valueOfProperty: #SuperSwikiRename ifAbsent: [false].
	world removeProperty: #SuperSwikiRename.
	^want

