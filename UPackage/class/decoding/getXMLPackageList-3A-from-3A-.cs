getXMLPackageList: listname from: element
	| listElement |
	listElement _ element elementAt: listname.
	listElement ifNil: [ ^#() ].
	^listElement elements collect: [ :nameXML |
		nameXML contents first string ]
