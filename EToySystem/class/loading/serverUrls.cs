serverUrls
	| list |
	list _  #('doltest1.disney.com/squeak/'
	'www.webpage.com/~kaehler2/').

	(list includes: Socket deadServer) ifTrue: [
		list _ list asOrderedCollection.
		list remove: Socket deadServer ifAbsent: [].
		list addLast: Socket deadServer].

	^ list asArray