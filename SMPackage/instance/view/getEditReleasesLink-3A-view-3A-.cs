getEditReleasesLink: aBuilder view: aView
	"Return a link for using on the web."

	^aBuilder getLink: 'package/', id asString, '/editreleases' text: 'edit releases' view: aView