font: aFont emphasis: emphasisCode
	font _ aFont.
	emphasis _ emphasisCode.
	self fitContents.
"
in inspector say,
	 self font: (TextStyle default fontAt: 2) emphasis: 1
"