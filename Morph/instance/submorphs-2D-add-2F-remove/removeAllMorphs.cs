removeAllMorphs

	self changed.
	submorphs do: [:m | m privateOwner: nil].
	submorphs _ EmptyArray.
	self layoutChanged.
