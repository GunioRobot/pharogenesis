viewedCategoryName
	"Answer the name to be used for the previously-viewed-methods category"

	true ifTrue: [^ #'-- active --'].

	^ '-- active --' asSymbol	 "For benefit of method-strings-containing-it search"
