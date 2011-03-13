setPreference: prefSymbol toValue: aBoolean
	(FlagDictionary at: prefSymbol ifAbsent: [nil]) == aBoolean
		ifFalse:
			[FlagDictionary at: prefSymbol put: aBoolean.
			self noteThatFlag: prefSymbol justChangedTo: aBoolean].
	^ aBoolean