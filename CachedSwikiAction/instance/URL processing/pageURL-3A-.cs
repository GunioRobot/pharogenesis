pageURL: aPage
	"make the url suited to aPage"
	^(self url),(self name),'/',aPage coreID,'.html'