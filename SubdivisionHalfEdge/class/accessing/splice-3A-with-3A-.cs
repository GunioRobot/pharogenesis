splice: edge1 with: edge2
	"This operator affects the two edge rings around the origins of a and b,
	and, independently, the two edge rings around the left faces of a and b.
	In each case, (i) if the two rings are distinct, Splice will combine
	them into one; (ii) if the two are the same ring, Splice will break it
	into two separate pieces.
	Thus, Splice can be used both to attach the two edges together, and
	to break them apart. See Guibas and Stolfi (1985) p.96 for more details
	and illustrations."
	| alpha beta t1 t2 t3 t4 |
	alpha := edge1 originNext rotated.
	beta := edge2 originNext rotated.

	t1 := edge2 originNext.
	t2 := edge1 originNext.
	t3 := beta originNext.
	t4 := alpha originNext.

	edge1 next: t1.
	edge2 next: t2.
	alpha next: t3.
	beta next: t4.