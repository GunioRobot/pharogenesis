searchString: aString notifying: aController
	"Take what the user typed and find all selectors containing it"
	searchString _ aString asString copyWithout: $ .
	self changed: #contactList.
	^true.