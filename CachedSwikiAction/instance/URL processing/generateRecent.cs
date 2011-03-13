generateRecent
	| file |
	file _ FileStream fileNamed: (self cacheDirectory),(self name),(ServerAction pathSeparator),'recent.html'.
	file nextPutAll: (HTMLformatter evalEmbedded: (self fileContents: source, 'recent.html')
					with: urlmap recentCache).
	file close.