decodeFromXMLElement: doc
	| package urlString |
	package _ self new.

	package name: (self getXMLPartNamed: 'name' from: doc).
	package version: (UVersion readFromString: (self getXMLPartNamed: 'version' from: doc)).
	package description: (self getXMLPartNamed: 'description' from: doc).
	urlString _ self getXMLPartNamed: 'url' from: doc.
	urlString isEmpty ifFalse: [
		(urlString withBlanksTrimmed beginsWith: 'http://(') ifFalse: [
	 		package url: (Url absoluteFromText: urlString). ] ].
	(doc elementAt: 'homepage') ifNotNil: [
		package homepage: (Url absoluteFromText: (self getXMLPartNamed: 'homepage' from: doc)) ].
	package maintainer: (self getXMLPartNamed: 'maintainer' from: doc).
	package provides: (self getXMLPackageList: 'provides' from: doc).
	package depends: (self getXMLPackageList: 'depends' from: doc).
	(doc elementAt: 'category') ifNotNil: [
		package category: (UPackageCategory readFromString: (self getXMLPartNamed: 'category' from: doc ))].
	(doc elementAt: 'squeakMapID') ifNotNil: [
		| idstr |
		idstr := self getXMLPartNamed: 'squeakMapID' from: doc.
		idstr isEmpty ifFalse: [
			package squeakMapID: (UUID fromString: idstr)]].
	^package