repair
	"Integrity repairs. This should not be neeed, but
	for some reason the map can obviously get messed up,
	not sure how."

	"SMSqueakMap default repair"
	
	"all objects should point back to me and not at another map"
	objects do: [:o | o map: self].
	
	"all releases should point back at the package they are in"
	self packages do: [:p | p releases do: [:r | r package: p]].
	
	"all releases in this map should point at a package in this map"
	self packageReleases do: [:r | | p |
		p := self object: r package id.
		p ifNil: [self error: 'Unknown package'].
		r package: p]