saveAsNumberedURLs
	"Write out all pages in this book that are not showing, onto a server.  The local disk could be the server.  For any page that does not have a SqueakPage and a url already, name that page file by its page number.  Any pages that are already totally out will stay that way."

	| stem list firstTime |
firstTime _ (self valueOfProperty: #url) == nil.
stem _ self getStemUrl.	"user must approve"
stem size = 0 ifTrue: [^ self].
firstTime ifTrue: [self setProperty: #futureUrl toValue: stem, '.bo'].
self reserveUrlsIfNeeded.
pages doWithIndex: [:aPage :ind | 	"does write the current page too"
	aPage isInMemory ifTrue: ["not out now"
		aPage presenter ifNotNil: [aPage presenter flushPlayerListCache].
		aPage saveOnURL: stem,(ind printString),'.sp'.
		]].

list _ pages collect: [:aPage |	 aPage sqkPage prePurge].
	"knows not to purge the current page"
list _ (list select: [:each | each notNil]) asArray.
"do bulk become:"
(list collect: [:each | each contentsMorph])
	elementsExchangeIdentityWith:
		(list collect: [:spg | MorphObjectOut new xxxSetUrl: spg url page: spg]).

self saveIndexOnURL.
self presenter ifNotNil: [self presenter flushPlayerListCache].
firstTime ifTrue: ["Put a thumbnail into the hand"
	URLMorph grabForBook: self.
	self setProperty: #futureUrl toValue: nil].	"clean up"
