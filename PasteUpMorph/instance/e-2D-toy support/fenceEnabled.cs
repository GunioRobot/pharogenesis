fenceEnabled

	^ self valueOfProperty: #fenceEnabled ifAbsent: [Preferences fenceEnabled]