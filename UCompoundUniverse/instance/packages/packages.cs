packages
	^Array streamContents: [ :pstr |
		components do: [ :univ |
			pstr nextPutAll: univ packages ] ]