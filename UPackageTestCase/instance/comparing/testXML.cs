testXML
	| xmlString stream readp1 readp2 readPackages readp3 |
	p2 version: (UVersion readFromString: '1.2').
	p1 description: 'blah blah <>&"'''.

	xmlString _ String streamContents: [ :str |
		str 
			nextPutAll: p1 xmlForExport;
			nextPutAll: p2 xmlForExport.
			
		str nextPutAll: '<package>
<name>IRCe</name>
<version>10.7.6</version>
<description>This is a significant rewrite of the built-in Squeak IRC client GUI. A new user interface includes having one console window per connection and then having all console messages, channel messages and private messages contained inside the main console window using tabbed swapped panes.                                         

Numerous other changes are also included but are not described here. The change-set contains documentation for all features added or modified.

Instructions at http://squeak.preeminent.org/irc-help/irc-help.html</description>
<url>http://kilana.unibe.ch:8888/IRC/Network-IRC-fc.10.7.6.mcz</url>
<maintainer></maintainer>
<provides></provides><depends></depends><conflicts></conflicts></package>' ].

	stream _ ReadStream on: xmlString.
	readPackages _ UPackage decodePackagesFromXMLStream: stream.

	self should: [ readPackages size = 3 ].
	readp1 _ readPackages first.
	readp2 _ readPackages second.
	readp3 _ readPackages third.

	self should: [ readp1 = p1 ].
	self should: [ readp2 = p2 ].
	self should: [ readp3 name = 'IRCe'].
	self should: [ readp3 version = (UVersion readFromString: '10.7.6')].
	