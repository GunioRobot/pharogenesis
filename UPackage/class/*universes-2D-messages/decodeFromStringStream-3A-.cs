decodeFromStringStream: str
	| package numDepends homePageText numProvides numConflicts urlString |
	package _ self new.
	package name: str next.
	package version: (UVersion readFromString: str next).
	package description: str next.
	urlString := str next.
	(urlString withBlanksTrimmed beginsWith: '(') ifFalse: [
		(urlString withBlanksTrimmed beginsWith: 'http://(') ifFalse: [
			package url: (Url absoluteFromText: urlString) ] ].

	homePageText _ str next.
	package homepage: (homePageText isEmpty ifTrue: [ nil ] ifFalse: [ homePageText asUrl ]).

	package maintainer: str next.

	numProvides _ Integer readFromString: str next. 
	package provides: (str next: numProvides).
	numDepends _ Integer readFromString: str next. 
	package depends: (str next: numDepends).
	numConflicts _ Integer readFromString: str next. 
	str next: numConflicts.  "skip them"

	str atEnd ifFalse: [
		package category: (UPackageCategory readFromString: str next)].
	
	str atEnd ifFalse: [
		| idstr |
		idstr := str next.
		idstr isEmpty ifFalse: [
			package squeakMapID:  (UUID fromString: idstr) ].
		].
	
	^package
