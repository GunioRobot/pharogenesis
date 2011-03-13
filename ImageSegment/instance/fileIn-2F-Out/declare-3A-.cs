declare: classThatIsARoot

	| nameOnArrival |
	"The class just arrived in this segment.  How fit it into the Smalltalk dictionary?  If it had an association, that was installed with associationDeclareAt:."

	nameOnArrival _ classThatIsARoot name.
	self declareAndPossiblyRename: classThatIsARoot.
	nameOnArrival == classThatIsARoot name ifTrue: [^self].
	renamedClasses ifNil: [RecentlyRenamedClasses _ renamedClasses _ Dictionary new].
	renamedClasses at: nameOnArrival put: classThatIsARoot name.

