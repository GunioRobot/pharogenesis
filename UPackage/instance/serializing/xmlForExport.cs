xmlForExport
	^String streamContents: [ :str |
		str
			nextPutAll: '<package>'; cr;
			nextPutAll: '<name>'; nextPutAll: self name escapeEntities; nextPutAll: '</name>'; cr;
			nextPutAll: '<version>'; nextPutAll:  self version printString escapeEntities; nextPutAll: '</version>'; cr;
			nextPutAll: '<category>'; print: self category; nextPutAll: '</category>'; cr;
			nextPutAll: '<description>'; nextPutAll: self description escapeEntities; nextPutAll: '</description>'; cr.
		self url ifNotNil: [
			str nextPutAll: '<url>'; nextPutAll: self url toText escapeEntities; nextPutAll: '</url>'; cr ].
		self homepage ifNotNil: [
			str nextPutAll: '<homepage>'; nextPutAll:  self homepage toText escapeEntities; nextPutAll: '</homepage>'; cr ].
		str nextPutAll: '<maintainer>'; nextPutAll: self maintainer escapeEntities; nextPutAll: '</maintainer>'; cr.
			
		str nextPutAll: '<provides>'.
		self printXMLPackageList: self provides on: str.
		str nextPutAll: '</provides>'.
		str nextPutAll: '<depends>'.
		self printXMLPackageList: self depends on: str.
		str nextPutAll: '</depends>'.
		squeakMapID ifNotNil: [
			str nextPutAll: '<squeakMapID>'.
			str nextPutAll: squeakMapID asString.
			str nextPutAll: '</squeakMapID>'.
			].

		str nextPutAll: '</package>'; cr. ]