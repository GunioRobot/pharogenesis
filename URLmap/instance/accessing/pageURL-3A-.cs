pageURL: aPage
	(aPage pageStatus = #new)
		ifTrue:
			[(action isKindOf: CachedSwikiAction)
			ifFalse: [^'<u>',(aPage name),'</u><a href="', 
				(action pageURL: aPage),'.edit">?</a>']
			ifTrue: [^'<u>',(aPage name),'</u><a href="',
				(action pwsURL),(action name),'.',(aPage coreID),'.edit">?</a>']
				"Underlines new but not yet edited pages"]
		ifFalse:
			[^'<a href="', (action pageURL: aPage),'">',(aPage name),'</a>']

"Logically, there should be editPageUrl in SwikiAction as well. After all,
we might want to define other URL schemes." 