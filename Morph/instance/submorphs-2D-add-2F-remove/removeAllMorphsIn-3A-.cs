removeAllMorphsIn: aCollection
"greatly speeds up the removal of *lots* of submorphs"
	| set |
	self changed.
	aCollection do: [:m | m privateOwner: nil].
	set _ IdentitySet new: aCollection size * 4 // 3.
	aCollection do: [:each | set add: each].
	submorphs _ submorphs reject: [ :each | set includes: each].
	self layoutChanged.
