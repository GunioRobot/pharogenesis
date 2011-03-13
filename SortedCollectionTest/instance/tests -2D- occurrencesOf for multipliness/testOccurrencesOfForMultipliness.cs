testOccurrencesOfForMultipliness

| collection element |
collection := self collectionWithEqualElements .
element := self elementTwiceInForOccurrences .

self assert: (collection occurrencesOf: element ) = 2.  