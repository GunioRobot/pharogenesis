numberOfTimesStringIsUsed: aString

	^ (self systemNavigation allSelect: [:method | method
							hasLiteralSuchThat: [:lit | lit class == String
									and: [lit includesSubstring: aString caseSensitive: true]]]) size