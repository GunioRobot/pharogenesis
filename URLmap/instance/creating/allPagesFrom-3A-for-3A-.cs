allPagesFrom: pageRef for: request
	| formattedPage refPages allPages peer |
	(request isKindOf: PWS) ifTrue: [peer _ request peerName] ifFalse:
[peer_''].
	formattedPage _ pageRef copy.  "Make a copy, then format the text."
	refPages _ OrderedCollection new.
	formattedPage formatted: (action formatter swikify: (pageRef text)

	linkhandler: [:link | self linkFor: link

				from: peer

				storingTo: refPages]).
	"This filtering should be generalized a tad, methinks. Perhaps
incorparated into the
	linkhandler."
	refPages _ refPages reject: [:page | page pageStatus = #new].
	"Now, put all referenced pages into the page"
	allPages _ WriteStream on: String new.
	allPages nextPutAll: '<h2>',(pageRef name),'</h2>', formattedPage
formatted.
	refPages do: [:page |
		allPages nextPutAll: '<h2>',(page name),'</h2>'.
		allPages nextPutAll: (HTMLformatter swikify: (page text)

	linkhandler: [:link | self linkFor: link

				from: peer

				storingTo:
(OrderedCollection new)]).].
	formattedPage formatted: allPages contents. "Put all the pages into THE
page"
	^formattedPage
