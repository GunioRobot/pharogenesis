fileOutCategory: category on: aFileStream initializing: aBool
	"Store on the file associated with aFileStream, all the classes associated 
	with the category and any requested shared pools."

	| first poolSet tempClass classes |
	classes _ (self superclassOrder: category).
	poolSet _ Set new.
	classes do: 
		[:class | class sharedPools do: [:eachPool | poolSet add: eachPool]].
	poolSet size > 0 ifTrue:
		[tempClass _ Class new.
		tempClass shouldFileOutPools ifTrue:
			[poolSet _ poolSet select: [:aPool | tempClass shouldFileOutPool: (Smalltalk keyAtIdentityValue: aPool)].
			poolSet do: [:aPool | tempClass fileOutPool: aPool onFileStream: aFileStream]]].
	first _ true.
	classes do: 
		[:class | 
		first
			ifTrue: [first _ false]
			ifFalse: [aFileStream cr; nextPut: Character newPage; cr].
		class
			fileOutOn: aFileStream
			moveSource: false
			toFile: 0
			initializing: false].
	aBool ifTrue:[classes do:[:cls| cls fileOutInitializerOn: aFileStream]].