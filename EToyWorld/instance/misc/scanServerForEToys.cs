scanServerForEToys
	| urls names |
	(Preferences valueOfFlag: #guessIfDOLProxyIsNeeded)
		ifTrue: [EToySystem guessDOLProxy].
	urls _ EToySystem newEToysOn: 
			(EToySystem serverUrls collect: [:aUrl | aUrl, 'etoys/']).
	urls _ urls, (EToySystem previewEToysOn:
			(EToySystem serverUrls collect: [:aUrl | aUrl, 'etoys/'])).	"Pref tested inside it"
	names _ urls collect: [:each | (each findTokens: '/') last].
	names with: urls do:
		[:n :u | self addEToy: (EToyPlaceHolder new url: u title: n sansPeriodSuffix)].

	"this method may be running in a separate thread. thus,
	 we must be sure that the front cover is still showing before
	 updating the list of etoys"
	(submorphs includes: frontCover) ifTrue: [self adjustTabs].
