center
	| pt1 pt2 pt3 l1 l2 l3 sum |
	pt1 _ e1 center.
	pt2 _ e2 center.
	pt3 _ e3 center.
	l1 _ e1 length.
	l2 _ e2 length.
	l3 _ e3 length.
	sum _ l1 + l2 + l3.
	^((pt1 * l1) + (pt2 * l2) + (pt3 * l3)) / sum
	"^(p1 + p2 + p3) / 3.0"