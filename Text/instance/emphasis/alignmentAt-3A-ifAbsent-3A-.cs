alignmentAt: characterIndex ifAbsent: aBlock
	| attributes emph |
	self size = 0 ifTrue: [^aBlock value].
	emph _ nil.
	attributes _ runs at: characterIndex.
	attributes do:[:att | (att isKindOf: TextAlignment) ifTrue:[emph _ att]].
	^ emph ifNil: aBlock ifNotNil:[emph alignment]