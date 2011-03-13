loadPreferencesFrom: aFileName
	| stream params dict desktopColor |
	stream := ReferenceStream fileNamed: aFileName.
	params := stream next.
	self assert: (params isKindOf: IdentityDictionary).
	params removeKey: #PersonalDictionaryOfPreferences.
	dict := stream next.
	self assert: (dict isKindOf: IdentityDictionary).
	desktopColor := stream next.
	stream close.
	dict keysAndValuesDo:
		[:key :value | (self preferenceAt: key ifAbsent: [nil]) ifNotNil:
			[:pref | pref preferenceValue: value preferenceValue]].

	params keysAndValuesDo: [ :key :value | self setParameter: key to: value ].

	World fillStyle: desktopColor 