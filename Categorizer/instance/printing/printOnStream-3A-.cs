printOnStream: aStream 
	"Refer to the comment in Object|printOn:."

	| elementIndex  |
	elementIndex _ 1.
	1 to: categoryArray size do: 
		[:i | 
		aStream print: '(';
		write:(categoryArray at:i).		" is the asString redundant? "

		[elementIndex <= (categoryStops at: i)]
			whileTrue: 
				[aStream print:' '; write:(elementArray at: elementIndex).
				elementIndex _ elementIndex + 1].
		aStream print:')'.
		aStream cr]