pageCacheURL: aPage
	^'<a href="',(action cacheURL),(action name),'/',aPage coreID,'.html">',(aPage name),'</a>'