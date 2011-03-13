printXMLPackageList: names on: stream
	names do: [ :n |
		stream nextPutAll: ' <packagename>'; nextPutAll: n escapeEntities; nextPutAll: '</packagename>' ].