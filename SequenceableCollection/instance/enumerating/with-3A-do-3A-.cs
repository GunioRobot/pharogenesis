with: otherCollection do: twoArgBlock 
	"Evaluate twoArgBlock with corresponding elements from this collection and otherCollection."
	1 to: self size do:
		[:index |
		twoArgBlock value: (self at: index)
				value: (otherCollection at: index)]