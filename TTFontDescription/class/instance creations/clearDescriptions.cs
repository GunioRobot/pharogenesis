clearDescriptions
"
	self clearDescriptions
"

	Descriptions _ Set new.
	Default ifNotNil: [Descriptions add: Default].
