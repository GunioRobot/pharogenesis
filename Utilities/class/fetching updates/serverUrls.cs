serverUrls 
	"Return the current list of server URLs.  For code updates.  Format of UpdateUrlLists is 
#( ('squeak updates' ('url1' 'url2'))
    ('some other updates' ('url3' 'url4')))"

	| list |
	list := UpdateUrlLists first last.

	"If there is a dead server, return a copy with that server last" 
	Socket deadServer ifNotNil: [
		list clone withIndexDo: [:aName :ind |
		(aName beginsWith: Socket deadServer) ifTrue: [
			list := list asOrderedCollection.	"and it's a copy"
			list removeAt: ind.
			list addLast: aName]]
	].

	^ list asArray