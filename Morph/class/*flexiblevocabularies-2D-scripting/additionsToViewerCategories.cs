additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the
	phrases this kind of morph wishes to add to various Viewer categories.

	This version factors each category definition into a separate method.

	Subclasses that have additions can either:
		- override this method, or
		- (preferably) define one or more additionToViewerCategory* methods.

	The advantage of the latter technique is that class extensions may be added
	by external packages without having to re-define additionsToViewerCategories.
	"
	^#()