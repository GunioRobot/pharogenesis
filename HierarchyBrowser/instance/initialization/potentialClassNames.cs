potentialClassNames
	"Answer the names of all the classes that could be viewed in this browser"
	^ self classList collect:
		[:aName | aName copyWithout: $ ]