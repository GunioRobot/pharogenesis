analyzeSegment: aSegment
	"I return a collection of arrays. Each array represents an object in the segment. The first element is the name of its class and the second element is an array of the class of its instance variables."

	| contents |
	contents := OrderedCollection new.
	aSegment objectJunksDo: [ :classname :header :fields |
		contents add: (Array
			with: classname
			with: (fields asOrderedCollection collect: [ :p |
				aSegment printTypeOf: p ]) asArray) ].
	^ contents