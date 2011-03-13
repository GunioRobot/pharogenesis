standardUniverses
	^Array streamContents: [ :str |
		components do: [ :comp |
			str nextPutAll: comp standardUniverses  ] ]