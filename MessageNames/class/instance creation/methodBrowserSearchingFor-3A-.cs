methodBrowserSearchingFor: searchString
	"Answer an method-browser window whose search-string is initially as indicated"

	| aWindow |
	aWindow _ self new inMorphicWindowWithInitialSearchString: searchString.
	aWindow applyModelExtent.
	^ aWindow