fullDrawOn: aCanvas

	running ifFalse: [
		^aCanvas clipBy: (bounds translateBy: aCanvas origin)
				during:[:clippedCanvas| super fullDrawOn: clippedCanvas]].
	aCanvas drawMorph: self.
