adjustTargetRepeatingInterval: aFractionalPoint

	| n |

	n _ 2 raisedTo: ((aFractionalPoint x * 12) rounded max: 1).
	self targetProperties delayBetweenFirings: n.
