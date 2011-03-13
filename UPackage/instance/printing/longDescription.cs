longDescription
	^Text streamContents: [ :str |
		str nextPutAll: self description; cr; cr.
		str nextPutAll: 'Category: '; print: self category; cr.
		self provides isEmpty ifFalse: [
			str nextPutAll: 'Provides:'; cr.
			self provides do: [ :depName |
				str tab; nextPutAll: depName; cr ].
			str cr].
		self  depends isEmpty ifFalse: [
			str nextPutAll: 'Depends on:'; cr.
			self  depends do: [ :depName |
				str tab; nextPutAll: depName; cr ].
			str cr].
		str nextPutAll: ('Maintained by: ', self  maintainer); cr.
		str nextPutAll: 'Downloads from: '.
		self  url ifNil: [ str nextPutAll: '(no url)' ] ifNotNil: [ str nextPutAll: self  url asString ].
		str cr.
		self  homepage ifNotNil: [
			str nextPutAll: 'Homepage: '.
			str nextPutAll: (Text string: self homepage asString attribute: (TextURL new url: self homepage asString)).
			str cr].
		self squeakMapID ifNotNil: [
			| smurl |
			str nextPutAll: 'SqueakMap UUID: ', self squeakMapID asString, String cr.

			smurl := 'http://map.squeak.org/package/', self squeakMapID asString.
			str nextPutAll: (Text string: '[browse SqueakMap web page]' attribute: (TextURL new url: smurl)).
			str cr.
			
			str nextPutAll: (Text string: '[open SqueakMap browser]' attribute: (TextDoIt evalString: 'USqueakMapUtil browsePackageID: (UUID fromString: ''', self squeakMapID asString, ''')')).
			str cr.
			]. ] .
