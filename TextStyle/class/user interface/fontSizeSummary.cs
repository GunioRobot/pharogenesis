fontSizeSummary
	"Open a text window with a simple summary of the available sizes in each of the fonts in the system."

	"TextStyle fontSizeSummary"
	| aString aList |
	aList _ self knownTextStyles.
	aString _ String streamContents:
		[:aStream |
			aList do: [:aStyleName |
				aStream nextPutAll:
					aStyleName, '  ',
					(self fontPointSizesFor: aStyleName) asArray storeString.
				aStream cr]].
	(StringHolder new contents: aString)
		openLabel: 'Font styles and sizes' translated