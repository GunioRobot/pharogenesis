findPackage: aString notifying: aView 
	"Search and select a package with the given (sub) string"

	| index list match |
	match := aString asString asLowercase.
	index := self packagesListIndex.
	list := self packageNameList.
	list isEmpty ifTrue: [^self].
	index + 1 to: list size
		do: 
			[:i | 
			((list at: i) asLowercase includesSubString: match) 
				ifTrue: [^self packagesListIndex: i]].
	"wrap around"
	1 to: index
		do: 
			[:i | 
			((list at: i) asLowercase includesSubString: match) 
				ifTrue: [^self packagesListIndex: i]].
	self inform: 'No package matching ' , aString asString