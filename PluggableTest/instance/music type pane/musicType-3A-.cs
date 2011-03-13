musicType: anInteger

	| oldArtist |
	oldArtist := self artistName.
	musicTypeIndex := anInteger.  "this changes artists list"
	artistIndex := self artistList indexOf: oldArtist.
	self changed: #musicType.
	self changed: #artistList.
