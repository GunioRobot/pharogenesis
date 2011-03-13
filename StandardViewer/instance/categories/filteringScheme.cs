filteringScheme
	"Answer the filtering scheme to be used in the receiver.  This architecture, rather fully prototyped earlier, is not yet really incorporated in the current corpus of released code, but will kick in later hopefully"

	| schemeToUse what |
	schemeToUse _
		self valueOfProperty: #filteringScheme ifAbsent: 
			[what _ Preferences defaultUserLevel == 1
				ifTrue:	[#minimal]
				ifFalse:	[#most].
			self setProperty: #filteringScheme toValue: what.
			what].

	^ schemeToUse