setEmphasisHere

	emphasisHere _ (paragraph text attributesAt: (startBlock stringIndex-1 max: 1))
					select: [:att | att mayBeExtended]