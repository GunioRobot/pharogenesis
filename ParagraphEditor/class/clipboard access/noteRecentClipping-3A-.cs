noteRecentClipping: text
	"Keep most recent clippings in a queue for pasteRecent (paste... command)"

	text isEmpty ifTrue: [^ self].
	text size > 50000 ifTrue: [^ self].
	RecentClippings ifNil: [RecentClippings _ OrderedCollection new].
	(RecentClippings includes: text) ifTrue: [^ self].
	RecentClippings addFirst: text.
	[RecentClippings size > 5] whileTrue: [RecentClippings removeLast].
