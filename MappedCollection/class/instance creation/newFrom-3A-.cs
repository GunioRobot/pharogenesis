newFrom: aCollection 
	"Answer an instance of me containing the same elements as aCollection."

	^ self collection: aCollection map: (1 to: aCollection size)

"	MappedCollection newFrom: {1. 2. 3}
	{4. 3. 8} as: MappedCollection
"