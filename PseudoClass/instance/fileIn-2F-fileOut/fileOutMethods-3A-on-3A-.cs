fileOutMethods: aCollection on: aStream
	"FileOut all methods with selectors taken from aCollection"
	| cat categories |
	categories := Dictionary new.
	aCollection do:[:sel|
		cat := self organization categoryOfElement: sel.
		cat = self removedCategoryName ifFalse:[
			(categories includesKey: cat) 
				ifFalse:[categories at: cat put: Set new].
			(categories at: cat) add: sel].
	].
	categories associationsDo:[:assoc|
		cat := assoc key.
		aStream cr; cr; nextPut:$!; nextChunkPut:(String streamContents:[:s|
			s nextPutAll: self fullName; nextPutAll:' methodsFor: '; print: cat asString]).
		assoc value do:[:sel|
			aStream cr.
			aStream nextChunkPut: (self sourceCodeAt: sel).
		].
		aStream space; nextPut:$!.
	].