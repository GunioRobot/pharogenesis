atCol: x
	"Answer a whole column."

	| column |
	column _ contents class new: self height.
	1 to: self height do: [:index | column at: index put: (self at: x at: index)].
	^ column