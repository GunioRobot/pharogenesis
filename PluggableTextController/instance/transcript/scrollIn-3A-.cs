scrollIn: scrollRect
	"Altered from selectAndScroll so can use with null clipRect"
	"Scroll until the selection is in the view and then highlight it."
	| deltaY |
	deltaY _ self stopBlock top - scrollRect top.
	deltaY >= 0 
		ifTrue: [deltaY _ self stopBlock bottom - scrollRect bottom max: 0].
						"check if stopIndex below bottom of scrollRect"
	deltaY ~= 0 
		ifTrue: [self scrollBy: (deltaY abs + paragraph lineGrid - 1) * deltaY sign]