fontSizeSummary
	"Utilities fontSizeSummary"
	| aString aList |
	aList _ Utilities knownTextStyles.
	aString _ String streamContents:
		[:aStream |
			aList do: [:aStyleName |
				aStream nextPutAll:
					aStyleName, '  ',
					(Utilities fontPointSizesFor: aStyleName) asArray storeString.
				aStream cr]].
	(StringHolder new contents: aString)
		openLabel: 'Font styles and sizes'