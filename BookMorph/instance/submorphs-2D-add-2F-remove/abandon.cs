abandon
	"Like delete, but we really intend not to use this morph again.  Make the page cache release the page object."

	| pg |
	self delete.
	pages do: [:aPage |
		(pg _ aPage sqkPage) ifNotNil: [
			pg contentsMorph == aPage ifTrue: [
					pg contentsMorph: nil]]].