mouseAdjust: evt in: aMorph

	| fractionalPosition feedBack testExtent |

	feedBack _ self showSliderFeedback: nil.
	feedBack world ifNil: [
		feedBack bottomLeft: evt cursorPoint - (0@8)
	].
	testExtent _ 100@100.		"the real extent may change"
	fractionalPosition _ (evt cursorPoint - aMorph topLeft) / testExtent.
	self 
		perform: (aMorph valueOfProperty: #changeSelector)
		with: fractionalPosition
