printOn: aStream 
	"Refer to the comment in Object|printOn:."

	| elementIndex |
	elementIndex _ 1.
	1 to: categoryArray size do: 
		[:i | 
		aStream nextPut: $(.
		(categoryArray at: i) asString printOn: aStream.
		[elementIndex <= (categoryStops at: i)]
			whileTrue: 
				[aStream space; nextPutAll: (elementArray at: elementIndex).
				elementIndex _ elementIndex + 1].
		aStream nextPut: $); cr]