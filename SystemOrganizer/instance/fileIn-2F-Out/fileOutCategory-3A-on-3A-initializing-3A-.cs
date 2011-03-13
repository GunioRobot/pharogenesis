fileOutCategory: category on: aFileStream initializing: aBool
	"Store on the file associated with aFileStream, all the traits and classes associated 
	with the category and any requested shared pools in the right order."

	| first poolSet tempClass classes traits |
	traits _ self orderedTraitsIn: category.
	classes _ self superclassOrder: category.
	poolSet _ Set new.
	classes do:  [:class | class sharedPools do: [:eachPool | poolSet add: eachPool]].
	poolSet size > 0 ifTrue: [
		tempClass _ Class new.
		tempClass shouldFileOutPools ifTrue: [
			poolSet _ poolSet select: [:aPool |
				tempClass shouldFileOutPool: (Smalltalk keyAtIdentityValue: aPool)].
			poolSet do: [:aPool | tempClass fileOutPool: aPool onFileStream: aFileStream]]].
	first _ true.
	traits, classes do: [:each | 
		first
			ifTrue: [first _ false]
			ifFalse: [aFileStream cr; nextPut: Character newPage; cr].
		each
			fileOutOn: aFileStream
			moveSource: false
			toFile: 0
			initializing: false].
	aBool ifTrue: [classes do: [:cls | cls fileOutInitializerOn: aFileStream]].