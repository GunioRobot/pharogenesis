musicType: anInteger

	| oldArtist |
	oldArtist _ self artistName.
	musicTypeIndex _ anInteger.  "this changes artists list"
	artistIndex _ self artistList indexOf: oldArtist.
	self changed: #musicType.
	self changed: #artistList.
