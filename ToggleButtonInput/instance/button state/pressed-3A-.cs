pressed: aBoolean
	state _ aBoolean.
	self changed: #pressed.
	button ifNotNil: [button step].
	^true