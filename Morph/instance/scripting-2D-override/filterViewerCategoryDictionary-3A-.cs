filterViewerCategoryDictionary: dict
	"dict has keys of categories and values of priority.
	You can re-order or remove categories here."

	Preferences eToyFriendly
		ifTrue: [dict removeKey: #layout].