testDiffusePrim
	"This test should diffuse the initial value in the center cell so that each cell has 1000."
	"StarSqueakMorph new testDiffusePrim"

	| src dst |
	src := Bitmap new: 49.
	src at: 25 put: 49000.
	dst := Bitmap new: 49.
	self primDiffuseFrom: src to: dst width: 7 height: 7 delta: 3.
	^ dst asArray
