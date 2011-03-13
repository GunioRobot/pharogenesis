updateJoinOffsets
	"Update the src and dst offsets in the join morph
	to match the src and dst tex scroll offsets."

	self joinMorph
		srcOffset: 0 @ self srcMorph scroller offset y negated;
		dstOffset: 0 @ self dstMorph scroller offset y negated;
		changed