scrollToYAbsolute: yValue

	| transform transformedPoint |

	transform _ scroller transformFrom: self.
	transformedPoint _ transform localPointToGlobal: 0@yValue.

	self scrollBy: 0@(bounds top - transformedPoint y).
