setUp
	p1 _ UPackage new.
	p1 name: 'Scamper'.
	p1 category: (UPackageCategory withComponents: #('Networking')).
	p1 description: 'A web browser'.
	p1 url: 'http://www.squeak.org' asUrl.
	p1 homepage: p1 url.
	p1 version: (UVersion readFromString: '1.0').
	p1 maintainer: 'John Doe'.

	p2 _ p1 deepCopy.
