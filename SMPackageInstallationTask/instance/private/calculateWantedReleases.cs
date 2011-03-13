calculateWantedReleases
	"The user gave us wanted packages.
	We need to figure out which actual releases of those
	we should try to install."

	| rel |
	wantedReleases := Set new.
	wantedPackages do: [:p | rel := self idealReleaseFor: p.
		rel ifNotNil: [wantedReleases add: rel]]