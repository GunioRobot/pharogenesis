newPages: pageList currentIndex: index
	"Replace all my pages with the given list of BookPageMorphs. Make the current page be the page with the given index."

	pages _ pages species new.
	pages addAll: pageList.
	pages isEmpty ifTrue: [^ self insertPage].
	self goToPage: index.
