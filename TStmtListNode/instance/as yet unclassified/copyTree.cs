copyTree

	^self class new
		setArguments: arguments copy
		statements: (statements collect: [ :s | s copyTree ])