getCoEditReleasesLink: aBuilder view: aView
	"Return a link for using on the web."

	^aBuilder getLink: 'copackage/', id asString, '/editreleases' text: 'edit releases' view: aView