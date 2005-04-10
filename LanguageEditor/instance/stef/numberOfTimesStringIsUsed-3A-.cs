numberOfTimesStringIsUsed: aString

	^ (self systemNavigation allSelect: [:method | method
							hasLiteralSuchThat: [:lit | lit isString
									and: [lit includesSubstring: aString caseSensitive: true]]]) size