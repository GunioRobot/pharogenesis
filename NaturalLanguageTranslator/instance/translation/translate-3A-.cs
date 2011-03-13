translate: aString
	^self generics
		at: aString
		ifAbsent: [self class registeredPhraseFor: aString. 
					self changed: #untranslated. 
					self localeID hasParent
			ifTrue: [(self class localeID: self localeID parent) translate: aString]
			ifFalse: [aString]]