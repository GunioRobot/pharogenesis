allClassesDo: aBlock
	"Evaluate the argument, aBlock, for each class in the system."

	(self classNames collect: [:name | self at: name]) do: aBlock