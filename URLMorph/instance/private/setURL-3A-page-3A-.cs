setURL: aURLString page: aSqueakPage
	"Initialize the receiver for the given URL and page."

	url _ aURLString.
	page _ aSqueakPage.
	page ifNotNil: [self pageHasChanged: page].
