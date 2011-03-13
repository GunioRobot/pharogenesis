do: aBlock
	"Refer to the comment in Collection|do:."
	| dep |
	1 to: self basicSize do:[:i|
		(dep := self at: i) ifNotNil:[aBlock value: dep]].