setEmphasisHere

	emphasisHere _ (paragraph text attributesAt: (startBlock stringIndex-1 max: 1) forStyle: paragraph textStyle)
					select: [:att | att mayBeExtended]