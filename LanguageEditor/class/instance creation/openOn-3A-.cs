openOn: aLanguage 
	"open an instance on aLanguage"
	World submorphs
		do: [:each | ""
			((each isKindOf: LanguageEditor)
					and: [each translator == aLanguage])
				ifTrue: [""
					self ensureVisibilityOfWindow: each.
					^ self]].
	""
	^ (self on: aLanguage) openInWorld